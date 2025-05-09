using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Base;

namespace TechStore.BLL.DtoModels.CartItem
{
    public class CartItemUpdateDto:BaseDto
    {
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
    }
}
