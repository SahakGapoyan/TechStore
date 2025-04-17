using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.BLL.DtoModels.OrderItem
{
    public class OrderItemAddDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
