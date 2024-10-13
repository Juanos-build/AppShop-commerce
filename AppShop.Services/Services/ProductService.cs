using AppShop.Models.Context;
using AppShop.Models.Context.Interfaces;
using AppShop.Models.Entities;
using AppShop.Services.Helpers.Extension;
using AppShop.Services.Helpers.Settings;
using AppShop.Services.Interfaces;

namespace AppShop.Services.Services
{
    public class ProductService : IProductService, IDisposable
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
        ~ProductService()
        {
            Dispose(false);
        }

        #endregion

        private readonly AppSettings _AppSettings = AppSettings.Settings;
        private readonly DaoFactory _factory;
        private readonly ITransactionDao _objTransaction;
        public ProductService()
        {
            _factory = DaoFactory.GetDaoFatory(_AppSettings.Connection);
            _objTransaction = _factory.GetTransactionDao();
        }

        public async Task<Response<GetProductsDto>> GetProducts(int pageNumber, int pageSize)
        {
            var response = new Response<GetProductsDto>();
            try
            {
                response.Result = await _objTransaction.GetProducts(pageNumber, pageSize);
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

        public async Task<Response<ProductDto>> GetProductById(int id)
        {
            var response = new Response<ProductDto>();
            try
            {
                response.Result = await _objTransaction.GetProductById(id);
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
