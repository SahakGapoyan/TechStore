﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BLL.DtoModels.CartItem
{
    public class CartItemAddDto
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
