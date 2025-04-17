using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Order;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.OrderMap
{
    public class OrderMapping:Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<Order, OrderAddDto>().ReverseMap();
        }
    }
}
