using AppShop.Models.Entities;

namespace AppShop.Models.Context.Interfaces
{
    public interface ITransactionDao
    {
        Task<GetProductsDto> GetProducts(int pageNumber, int pageSize);
        Task<bool> AddOrder(OrderDto request);
        Task<ProductDto> GetProductById(int id);
    }
}
