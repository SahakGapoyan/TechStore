using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.OrderItem;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrderItemService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddOrderItem(int oderId, OrderItemAddDto orderItemAddDto, CancellationToken token = default)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemAddDto);
            orderItem.OrderId = oderId;
            await _uow.OrderItemRepository.AddOrderItem(orderItem, token);
            await _uow.SaveAsync(token);
        }

        public async Task<OrderItemDto?> GetOrderItemById(int orderItemId, CancellationToken token = default)
        {
            return _mapper.Map<OrderItemDto>(await _uow.OrderItemRepository.GetOrderItemById(orderItemId, token));
        }

        public async Task<(Result, IEnumerable<OrderItemDto>)> GetOrderItemsByUserId(int userId, CancellationToken token = default)
        {
            var user = await _uow.UserRepository.GetById(userId, token);
            if(user==null)
            {
                return (Result.Error(ErrorType.NotFound, $"There is nor User by {userId} Id"), null);
            }
            return(Result.Ok(),_mapper.Map<List<OrderItemDto>>(await _uow.OrderItemRepository.GetOrderItemsByUserId(userId,token)));
        }
    }
}
