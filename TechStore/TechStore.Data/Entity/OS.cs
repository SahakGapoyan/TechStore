﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class OS : BaseEntity
    {
        public string Name { get; set; } = default!;
        public IEnumerable<SmartPhone> SmartPhones { get; set; } = new List<SmartPhone>();
        public IEnumerable<Laptop> Laptops { get; set; } = new List<Laptop>();

    }
}
