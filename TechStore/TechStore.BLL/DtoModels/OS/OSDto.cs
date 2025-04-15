using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Base;

namespace TechStore.BLL.DtoModels.OS
{
    public class OSDto : BaseDto
    {
        public string Size { get; set; } = default!;
    }
}
