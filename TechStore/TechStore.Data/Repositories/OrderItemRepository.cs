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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly TechStoreDbContext _context;

        public OrderItemRepository(TechStoreDbContext context)
        {
            _context = context;
        }
        public async Task AddOrderItem(OrderItem orderItem, CancellationToken token = default)
        {
            await _context.OrderItems.AddAsync(orderItem, token);
        }

        public async Task<OrderItem?> GetOrderItemById(int orderItemId, CancellationToken token = default)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(o => o.Id == orderItemId);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByUserId(int userId, CancellationToken token = default)
        {
            return await _context.OrderItems
                 .Include(o => o.Order)
                 .Include(o=>o.Product)
                 .Where(o => o.Order.UserId == userId)
                 .ToListAsync(token);
        }
    }
}