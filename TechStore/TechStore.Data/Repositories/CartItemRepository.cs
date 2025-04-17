using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.DbContext;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.Data.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly TechStoreDbContext _techStoreDbContext;

        public CartItemRepository(TechStoreDbContext techStoreDbContext)
        {
            _techStoreDbContext = techStoreDbContext;
        }
        public async Task AddCartItem(CartItem cartItem, CancellationToken token)
        {
            await _techStoreDbContext.CartItems.AddAsync(cartItem, token);
        }

        public async Task DeleteCartItem(CartItem cartItem)
        {
            _techStoreDbContext.CartItems.Remove(cartItem);
        }

        public async Task<CartItem?> GetById(int cartItemId, CancellationToken token = default)
        {
            return await _techStoreDbContext.CartItems.FirstOrDefaultAsync(c => c.Id == cartItemId, token);
        }

        public async Task<CartItem?> GetCartItemByUserAndProduct(int userId, int productId, CancellationToken token = default)
        {
            return await _techStoreDbContext.CartItems
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == userId);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByUserId(int userId, CancellationToken token)
        {
            return await _techStoreDbContext.CartItems
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ToListAsync(token);
        }

        public async Task UpdateCartItem(CartItem cartItem)
        {
            _techStoreDbContext.CartItems.Update(cartItem);
        }
    }
}
