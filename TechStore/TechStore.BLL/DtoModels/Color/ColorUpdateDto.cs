using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Base;

namespace TechStore.BLL.DtoModels.Color
{
    public class ColorUpdateDto : BaseDto
    {
        public string? Name { get; set; }
        public string? HexCode { get; set; }
    }
}
