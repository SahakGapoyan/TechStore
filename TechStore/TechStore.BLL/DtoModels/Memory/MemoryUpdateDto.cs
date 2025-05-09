using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Base;

namespace TechStore.BLL.DtoModels.Memory
{
    public class MemoryUpdateDto:BaseDto
    {
        public string? Size { get; set; }
    }
}
