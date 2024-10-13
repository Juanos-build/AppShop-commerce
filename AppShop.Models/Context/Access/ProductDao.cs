using AppShop.Models.Context.Interfaces;
using AppShop.Models.Context.Model;
using AppShop.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppShop.Models.Context.Access
{
    internal class ProductDao : IProductDao
    {
        private DataContext _dataContext;
        private readonly IMapper _mapper = MapperBootstrapper.Instance;

        public void SetTransaction(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<GetProductsDto> GetProducts(int pageNumber, int pageSize)
        {
            try
            {
                var totalProducts = await _dataContext.Products.CountAsync();

                var products = await (from product in _dataContext.Products
                                      join prodCat in _dataContext.ProductCategories on product.Id equals prodCat.ProductId
                                      join category in _dataContext.Categories on prodCat.CategoryId equals category.Id
                                      select new ProductDto
                                      {
                                          ProductId = product.Id,
                                          ProductCode = product.ProductCode,
                                          ProductName = product.ProductName,
                                          Description = product.Description,
                                          Price = product.Price,
                                          Stock = product.Stock,
                                          Image = product.Image,
                                          Categories = category.ProductCategories.Select(c => new CategoryDto
                                          {
                                              CategoryId = c.Category.Id,
                                              Name = c.Category.Name
                                          }).Distinct().ToList()
                                      })
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

                var result = new GetProductsDto
                {
                    Products = products,
                    TotalProducts = totalProducts,
                    CurrentPage = pageNumber,
                    TotalPages = pageSize
                };

                return result;
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
                var result = await _dataContext.Products.SingleOrDefaultAsync(p => p.Id == id);
                return result != null ? _mapper.Map<ProductDto>(result) : null;
            }
            catch
            {
                throw;
            }
        }
    }
}
