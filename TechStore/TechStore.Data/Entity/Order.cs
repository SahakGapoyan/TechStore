using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Enums;

namespace TechStore.Data.Entity
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string? ShippingAddress { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
