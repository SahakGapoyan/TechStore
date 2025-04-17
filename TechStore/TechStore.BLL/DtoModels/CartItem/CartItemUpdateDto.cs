using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BLL.DtoModels.CartItem
{
    public class CartItemUpdateDto
    {
        public decimal? CurrentPrice { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public decimal? SubTotal { get; set; }
    }
}
