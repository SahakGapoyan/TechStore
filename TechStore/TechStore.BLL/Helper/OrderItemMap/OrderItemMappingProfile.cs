using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.OrderItem;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.OrderItemMap
{
    public class OrderItemMappingProfile:Profile
    {
        public OrderItemMappingProfile()
        {
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemAddDto, OrderItem>();
        }
    }
}
