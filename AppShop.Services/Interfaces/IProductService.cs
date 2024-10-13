using AppShop.Models.Entities;

namespace AppShop.Services.Interfaces
{
    public interface IProductService
    {
        Task<Response<GetProductsDto>> GetProducts(int pageNumber, int pageSize);
        Task<Response<ProductDto>> GetProductById(int id);
    }
}
