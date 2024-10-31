using AppShop.Models.Entities;
using AppShop.Services.Interfaces;

namespace AppShop.Server.GraphQL.Mutation
{
    public class OrderMutation
    {
        public async Task<Response<bool>> AddOrder([Service] IOrderService orderService, OrderDto request)
        {
            return await orderService.AddOrder(request);
        }
    }
}
