using AppShop.Models.Context.Model;
using AppShop.Models.Entities;

namespace AppShop.Models.Context.Interfaces
{
    public interface IOrderDao
    {
        void SetTransaction(DataContext dataContext);
        Task<bool> AddOrder(OrderDto request);
    }
}
