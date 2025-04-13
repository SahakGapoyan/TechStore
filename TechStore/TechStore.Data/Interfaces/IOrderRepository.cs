using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersByUserId(int userId, CancellationToken token=default);
        Task<Order?> GetOrder(int orderId, CancellationToken token=default);
        Task AddOrder(Order order, CancellationToken token=default);
        Task UpdateOrder(Order order);
    }
}
