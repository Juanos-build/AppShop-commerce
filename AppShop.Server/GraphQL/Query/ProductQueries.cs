using AppShop.Models.Entities;
using AppShop.Services.Interfaces;

namespace AppShop.Server.GraphQL.Query
{
    public class ProductQueries
    {
        public async Task<Response<GetProductsDto>> GetProductsAsync([Service] IProductService productService, int pageNumber, int pageSize)
        {
            return await productService.GetProducts(pageNumber, pageSize);
        }

        public async Task<Response<ProductDto>> GetProductByIdAsync([Service] IProductService productService, int id)
        {
            return await productService.GetProductById(id);
        }
    }
}
