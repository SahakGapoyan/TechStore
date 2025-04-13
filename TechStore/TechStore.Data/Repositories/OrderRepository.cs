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
    public class OrderRepository : IOrderRepository
    {
        private readonly TechStoreDbContext _context;

        public OrderRepository(TechStoreDbContext context)
        {
            _context = context;
        }
        public async Task AddOrder(Order order, CancellationToken token)
        {
            await _context.Orders.AddAsync(order, token);
        }

        public async Task<Order?> GetOrder(int orderId, CancellationToken token)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId, token);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId, CancellationToken token)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync(token);
        }

        public async Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
        }
    }
}
