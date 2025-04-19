using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Order;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersByUserId(int userId, CancellationToken token = default);
        Task<OrderDto?> GetOrder(int orderId, CancellationToken token = default);
        Task AddOrder(int userId,OrderAddDto orderAddDto, CancellationToken token = default);
        Task<Result> UpdateOrder(int orderId,OrderUpdateDto orderUpdateDto,CancellationToken token=default);
    }
}
