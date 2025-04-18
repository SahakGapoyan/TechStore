using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.CartItem;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.CartItemMap
{
    public class CartItemMapping:Profile
    {
        public CartItemMapping()
        {
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(src => src.Product.Price));
            CreateMap<CartItem, CartItemAddDto>().ReverseMap();
        }
    }
}
