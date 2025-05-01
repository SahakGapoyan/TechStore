using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Base;

namespace TechStore.BLL.DtoModels.Product
{
    public class ProductSuggestionDto:BaseDto
    {
        public string Name { get; set; } = default!;
        public string ProductType { get; set; } = default!;
    }
}
