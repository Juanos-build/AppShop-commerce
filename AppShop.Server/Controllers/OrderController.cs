using AppShop.Models.Entities;
using AppShop.Services.Helpers.Extension;
using AppShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpPost("AddOrder")]
        [ProducesResponseType(typeof(ResponseProblem), (int)HttpStatusCode.BadRequest)]
        [Produces(typeof(Response<bool>))]
        public async Task<IActionResult> AddOrder([FromBody] OrderDto request)
        {
            var result = await _orderService.AddOrder(request);
            return result.IsSuccess ? Ok(result) : BadRequest(new ResponseProblem().Bad(result));
        }
    }
}
