using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Base;

namespace TechStore.BLL.DtoModels.Category
{
    public class CategoryDto:BaseDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
