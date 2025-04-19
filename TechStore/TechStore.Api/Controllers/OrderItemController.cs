using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.OrderItem;
using TechStore.BLL.Interfaces;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<List<OrderItemDto?>>> GetOrderItemsByUserId([FromRoute] int userId, CancellationToken token)
        {
            var result=await _orderItemService.GetOrderItemsByUserId(userId, token);
            if(!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                {
                    return NotFound(result.Item1.Message);
                }
            }
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<OrderItemDto?>> GetOrderItemById([FromRoute] int id, CancellationToken token)
        {
            var orderItem = await _orderItemService.GetOrderItemById(id, token);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrderItem([FromQuery] int orderId,[FromBody] OrderItemAddDto orderItemAddDto,CancellationToken token)
        {
            await _orderItemService.AddOrderItem(orderId,orderItemAddDto, token);
            return Ok();
        }
    }
}
