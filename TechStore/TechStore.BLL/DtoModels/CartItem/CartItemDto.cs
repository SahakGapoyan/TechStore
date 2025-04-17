using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Base;
using TechStore.BLL.DtoModels.Product;

namespace TechStore.BLL.DtoModels.CartItem
{
    public class CartItemDto:BaseDto
    {
        public decimal CurrentPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedAt { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public decimal SubTotal => Quantity * CurrentPrice;
    }
}
