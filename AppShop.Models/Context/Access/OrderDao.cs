using AppShop.Models.Context.Interfaces;
using AppShop.Models.Context.Model;
using AppShop.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppShop.Models.Context.Access
{
    internal class OrderDao : IOrderDao
    {
        private DataContext _dataContext;
        private readonly IMapper _mapper = MapperBootstrapper.Instance;

        public void SetTransaction(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddOrder(OrderDto request)
        {
            try
            {
                var customer = _mapper.Map<Customer>(request.Customer);

                var customerExist = await _dataContext.Customers
                    .Where(c =>
                        c.Email.Equals(customer.Email) &
                        c.Name.Equals(customer.Name) &
                        c.Address.Equals(customer.Address)).FirstOrDefaultAsync();

                if (customerExist == null)
                {
                    await _dataContext.Customers.AddAsync(customer);
                    await _dataContext.SaveChangesAsync();
                }
                else
                    customer.Id = customerExist.Id;

                var order = _mapper.Map<Order>(request);
                order.CustomerId = customer.Id;

                await _dataContext.Orders.AddAsync(order);
                await _dataContext.SaveChangesAsync();

                var orderProducts = _mapper.Map<List<ProductOrder>>(request.Products);

                orderProducts.ForEach(p => p.OrderId = order.Id);
                await _dataContext.ProductOrders.AddRangeAsync(orderProducts);
                await _dataContext.SaveChangesAsync();

                var products = _mapper.Map<List<Product>>(request.Products);
                foreach (var product in products)
                {
                    _dataContext.Attach(product);
                    _dataContext.Entry(product).Property(u => u.Stock).IsModified = true;
                    await _dataContext.SaveChangesAsync();
                }

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
