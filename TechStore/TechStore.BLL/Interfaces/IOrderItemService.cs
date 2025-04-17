using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.OrderItem;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetOrderItemsByUserId(int userId, CancellationToken token = default);
        Task<OrderItemDto?> GetOrderItemById(int orderItemId, CancellationToken token = default);
        Task AddOrderItem(int orderId,OrderItemAddDto orderItemAddDto, CancellationToken token = default);
    }
}
