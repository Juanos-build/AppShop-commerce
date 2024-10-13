using AppShop.Models.Context.Model;
using AppShop.Models.Entities;

namespace AppShop.Models.Context.Interfaces
{
    public interface IProductDao
    {
        void SetTransaction(DataContext dataContext);
        Task<GetProductsDto> GetProducts(int pageNumber, int pageSize);
        Task<ProductDto> GetProductById(int id);
    }
}
