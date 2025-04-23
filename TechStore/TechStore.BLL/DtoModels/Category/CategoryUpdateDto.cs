using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BLL.DtoModels.Category
{
    public class CategoryUpdateDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
