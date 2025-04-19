using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Order;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;
using TechStore.Data.Repositories;

namespace TechStore.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddOrder(int userId,OrderAddDto orderAddDto, CancellationToken token = default)
        {
            var order = _mapper.Map<Order>(orderAddDto);
            order.UserId = userId;
            await _uow.OrderRepository.AddOrder(order,token);
            await _uow.SaveAsync(token);
        }

        public async Task<OrderDto?> GetOrder(int orderId, CancellationToken token = default)
        {
            return _mapper.Map<OrderDto>(await _uow.OrderRepository.GetOrder(orderId));
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserId(int userId, CancellationToken token = default)
        {
            return _mapper.Map<List<OrderDto>>(await _uow.OrderRepository.GetOrdersByUserId(userId));
        }

        public async Task<Result> UpdateOrder(int orderId,OrderUpdateDto orderUpdateDto,CancellationToken token=default)
        {
            var order = await _uow.OrderRepository.GetOrder(orderId);
            if(order==null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            order.ShippingAddress = orderUpdateDto.ShippingAddress ?? order.ShippingAddress;
            order.Status = orderUpdateDto.Status ?? order.Status;
            await _uow.OrderRepository.UpdateOrder(order);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully Updated");
        }
    }
}
