using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Model;
using TechStore.BLL.DtoModels.Order;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<List<OrderDto>>> GetOrders([FromRoute] int userId,CancellationToken token)
        {
            return Ok(await _orderService.GetOrdersByUserId(userId, token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById([FromRoute] int id,CancellationToken token)
        {
            var order = await _orderService.GetOrder(id, token);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("userId{userId}")]
        public async Task<ActionResult> CreateOrder([FromRoute] int userId,[FromBody] OrderAddDto orderAddDto, CancellationToken token)
        {
            await _orderService.AddOrder(userId,orderAddDto,token);
            return Ok("Successfully created.");
        }

        [HttpPut("id/{id}")]
        public async Task<ActionResult> UpdateOrder([FromRoute] int id, [FromBody] OrderUpdateDto orderUpdateDto, CancellationToken token)
        {
            var result = await _orderService.UpdateOrder(id, orderUpdateDto, token);
            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }
            return Ok(result.Message);
        }
    }
}
