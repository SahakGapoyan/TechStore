using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Enums;

namespace TechStore.BLL.DtoModels.Order
{
    public class OrderUpdateDto
    {
        public OrderStatus? Status { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
