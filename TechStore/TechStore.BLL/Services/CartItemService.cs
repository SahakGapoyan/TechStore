using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.CartItem;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CartItemService(IUnitOfWork uow,IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddCartItem(CartItemAddDto cartItemAddDto, CancellationToken token = default)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemAddDto);
            await _uow.CartItemRepository.AddCartItem(cartItem,token);
            await _uow.SaveAsync(token);
        }

        public async Task<Result> DeleteCartItem(int cartItemId, CancellationToken token = default)
        {
            var cartItem = await _uow.CartItemRepository.GetById(cartItemId,token);
            if(cartItem==null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            await _uow.CartItemRepository.DeleteCartItem(cartItem);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully Deleted");
        }

        public async Task<CartItemDto?> GetById(int cartItemId, CancellationToken token = default)
        {
            return _mapper.Map<CartItemDto>(await _uow.CartItemRepository.GetById(cartItemId, token));
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItemsByUserId(int userId, CancellationToken token = default)
        {
            return _mapper.Map<List<CartItemDto>>(await _uow.CartItemRepository.GetCartItemsByUserId(userId, token));
        }

        public async Task<Result> UpdateCartItem(int cartItemId, CartItemUpdateDto cartItemUpdateDto, CancellationToken token = default)
        {
            var cartItem = await _uow.CartItemRepository.GetById(cartItemId, token);
            if(cartItem==null)
            {
                return Result.Error(ErrorType.NotFound);
            }
            await _uow.CartItemRepository.UpdateCartItem(cartItem);
            await _uow.SaveAsync(token);
            return Result.Ok("Successfully Updated");
        }
    }
}
