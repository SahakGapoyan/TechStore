using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface ICartItemRepository
    {
        Task<CartItem> GetById(int cartItemId,CancellationToken token=default);
        Task<IEnumerable<CartItem>> GetCartItemsByUserId(int userId, CancellationToken token = default);
        Task AddCartItem(CartItem cartItem, CancellationToken token = default);
        Task UpdateCartItem(CartItem cartItem);
        Task DeleteCartItem(CartItem cartItem);
    }
}
