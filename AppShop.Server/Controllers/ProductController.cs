using AppShop.Models.Entities;
using AppShop.Services.Helpers.Extension;
using AppShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet("GetProducts/{pageNumber}/{pageSize}")]
        [ProducesResponseType(typeof(ResponseProblem), (int)HttpStatusCode.BadRequest)]
        [Produces(typeof(Response<GetProductsDto>))]
        public async Task<IActionResult> GetProducts(int pageNumber, int pageSize)
        {
            var result = await _productService.GetProducts(pageNumber, pageSize);
            return result.IsSuccess ? Ok(result) : BadRequest(new ResponseProblem().Bad(result));
        }

        [HttpGet("GetProductById/{id}")]
        [ProducesResponseType(typeof(ResponseProblem), (int)HttpStatusCode.BadRequest)]
        [Produces(typeof(Response<ProductDto>))]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productService.GetProductById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(new ResponseProblem().Bad(result));
        }
    }
}
