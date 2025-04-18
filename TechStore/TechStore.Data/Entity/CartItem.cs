using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class CartItem : BaseEntity
    {
        public decimal CurrentPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.Now;
        public Product Product { get; set; } = default!;
        public int ProductId { get; set; }
        public User User { get; set; } = default!;
        public int UserId { get; set; }
        public decimal SubTotal { get; set; }
    }
}
