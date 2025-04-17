using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.CartItem;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface ICartItemService
    {
        Task<CartItemDto?> GetById(int cartItemId, CancellationToken token = default);
        Task<IEnumerable<CartItemDto>> GetCartItemsByUserId(int userId, CancellationToken token = default);
        Task AddCartItem(CartItemAddDto cartItemAddDto, CancellationToken token = default);
        Task<Result> UpdateCartItem(int cartItemId,CartItemUpdateDto cartItemUpdateDto,CancellationToken token=default);
        Task<Result> DeleteCartItem(int cartItemId,CancellationToken token=default);
    }
}
