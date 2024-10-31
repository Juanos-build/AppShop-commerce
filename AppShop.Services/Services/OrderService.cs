using AppShop.Models.Context;
using AppShop.Models.Context.Interfaces;
using AppShop.Models.Context.Model;
using AppShop.Models.Entities;
using AppShop.Services.Helpers.Extension;
using AppShop.Services.Interfaces;

namespace AppShop.Services.Services
{
    public class OrderService : IOrderService, IDisposable
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
                }
                disposed = true;
            }
        }

        // Destructor
        ~OrderService()
        {
            Dispose(false);
        }

        #endregion

        private readonly DaoFactory _factory;
        private readonly ITransactionDao _objTransaction;
        private readonly DataContext _dataContext;
        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
            _factory = DaoFactory.GetDaoFatory(_dataContext);
            _objTransaction = _factory.GetTransactionDao();
        }

        public async Task<Response<bool>> AddOrder(OrderDto request)
        {
            var response = new Response<bool>();
            try
            {
                foreach (var product in request.Products)
                {
                    var validStock = _objTransaction.GetProductById(product.ProductId).Result;
                    if (validStock.Equals(0))
                    {
                        throw new ResultException(
                            code: 404,
                            detail: $"product ({validStock.ProductName}) has not available stock ({validStock.Stock})");
                    }
                    else if (product.Stock > validStock.Stock)
                        throw new ResultException(
                            code: 404,
                            detail: $"one of the products has changed of Stock. product name({validStock.ProductName}) current ({product.Quantity}) available ({validStock.Stock})");
                }
                response.Result = await _objTransaction.AddOrder(request);
                response.Success();
            }
            catch (ResultException ex)
            {
                response.Error(ex);
            }
            catch (Exception ex)
            {
                response.Exception(ex);
            }
            return response;
        }
    }
}
