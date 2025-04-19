using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Brand;
using TechStore.BLL.DtoModels.CartItem;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemsController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<List<CartItemDto>>> GetCartItemsByUserId([FromRoute] int userId, CancellationToken token)
        {
            return Ok(await _cartItemService.GetCartItemsByUserId(userId, token));
        }

        [HttpGet("user/{userId}/product/{productId}")]
        public async Task<ActionResult<CartItemDto>> GetCartItemByUserAndProduct([FromRoute]int userId,[FromRoute] int productId, 
            CancellationToken token)
        {
            var cartItem = await _cartItemService.GetCartItemByUserAndProduct(userId, productId, token);
            if (cartItem == null)
                return NotFound();

            return Ok(cartItem);
        }

        [HttpGet("cartItemId/{cartItemId}")]
        public async Task<ActionResult<CartItemDto>> GetCartItemById([FromRoute] int cartItemId,CancellationToken token)
        {
            var cartItem = await _cartItemService.GetById(cartItemId, token);

            if (cartItem == null)
                return NotFound();

            return Ok(cartItem);
        }

        [HttpPost]
        public async Task<ActionResult> AddCartItem([FromBody]CartItemAddDto cartItemAddDto,[FromQuery] int userId, CancellationToken token = default)
        {
            await _cartItemService.AddCartItem(cartItemAddDto, userId, token);

            return Ok("Successfully created.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCartItem(int cartItemId, CartItemUpdateDto cartItemUpdateDto, 
            CancellationToken token = default)
        {
            var result = await _cartItemService.UpdateCartItem(cartItemId, cartItemUpdateDto, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }

        [HttpDelete("cartItemId/{cartItemId}")]
        public async Task<ActionResult> DeleteCartItem(int cartItemId, CancellationToken token = default)
        {
            var result = await _cartItemService.DeleteCartItem(cartItemId, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }
    }
}
