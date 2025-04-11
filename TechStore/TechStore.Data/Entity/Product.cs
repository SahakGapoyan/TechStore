using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class Product:BaseEntity
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public Category Category { get; set; } = default!;
        public int CategoryId { get; set; }
        public Brand Brand { get; set; } = default!;
        public int BrandId { get; set; }
        public Model Model { get; set; } = default!;
        public int ModelId { get; set; }
        public Color? Color { get; set; }
        public int ColorId { get; set; }

    }
}
