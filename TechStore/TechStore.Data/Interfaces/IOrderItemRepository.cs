using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsByUserId(int userId, CancellationToken token = default);
        Task<OrderItem?> GetOrderItemById(int orderItemId, CancellationToken token = default);
        Task AddOrderItem(OrderItem orderItem, CancellationToken token = default);
    }
}
