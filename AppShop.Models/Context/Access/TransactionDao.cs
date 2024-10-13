using AppShop.Models.Context.Interfaces;
using AppShop.Models.Context.Model;
using AppShop.Models.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppShop.Models.Context.Access
{
    public class TransactionDao : ITransactionDao, IDisposable
    {
        #region IDisposable
        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                    _dataTransaction.Dispose();
                }
                disposed = true;
            }
        }

        // Destructor
        ~TransactionDao()
        {
            Dispose(false);
        }
        #endregion

        DataContext _dataContext;
        IDbContextTransaction _dataTransaction;

        private readonly IProductDao _prod;
        private readonly IOrderDao _ord;

        private readonly DaoFactory _factory;
        public TransactionDao()
        {
            _factory = DaoFactory.GetDaoFatory(AccessDao.ConnectionString);
            _prod = _factory.GetProductDao();
            _ord = _factory.GetOrderDao();
        }

        public async Task<GetProductsDto> GetProducts(int pageNumber, int pageSize)
        {
            try
            {
                using (_dataContext = new DataContext(AccessDao.OptionsBuilder))
                {
                    using (_dataTransaction = _dataContext.Database.BeginTransaction())
                    {
                        try
                        {
                            _prod.SetTransaction(_dataContext);

                            var result = await _prod.GetProducts(pageNumber, pageSize);
                            await _dataTransaction.CommitAsync();
                            return result;
                        }
                        catch
                        {
                            await _dataTransaction.RollbackAsync();
                            throw;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AddOrder(OrderDto request)
        {
            try
            {
                using (_dataContext = new DataContext(AccessDao.OptionsBuilder))
                {
                    using (_dataTransaction = _dataContext.Database.BeginTransaction())
                    {
                        try
                        {
                            _ord.SetTransaction(_dataContext);

                            var result = await _ord.AddOrder(request);
                            await _dataTransaction.CommitAsync();
                            return result;
                        }
                        catch
                        {
                            await _dataTransaction.RollbackAsync();
                            throw;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            try
            {
                using (_dataContext = new DataContext(AccessDao.OptionsBuilder))
                {
                    using (_dataTransaction = _dataContext.Database.BeginTransaction())
                    {
                        try
                        {
                            _prod.SetTransaction(_dataContext);

                            var result = await _prod.GetProductById(id);
                            await _dataTransaction.CommitAsync();
                            return result;
                        }
                        catch
                        {
                            await _dataTransaction.RollbackAsync();
                            throw;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
