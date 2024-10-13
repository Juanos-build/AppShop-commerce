using AppShop.Models.Entities;

namespace AppShop.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Response<bool>> AddOrder(OrderDto request);
    }
}
