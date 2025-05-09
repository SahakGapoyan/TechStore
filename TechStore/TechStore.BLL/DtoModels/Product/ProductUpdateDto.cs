using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Base;
using TechStore.Data.Entity;

namespace TechStore.BLL.DtoModels.Product
{
    public class ProductUpdateDto:BaseDto
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public bool? IsAvailable { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? ColorId { get; set; }
        public List<string>? ImagesUrls { get; set; }
    }
}
