using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Base;

namespace TechStore.BLL.DtoModels.Brand
{
    public class BrandAddDto
    {
        public string Name { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
