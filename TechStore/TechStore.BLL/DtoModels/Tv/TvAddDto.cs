using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Product;

namespace TechStore.BLL.DtoModels.Tv
{
    public class TvAddDto:ProductAddDto
    {
        public string ScreenSize { get; set; }
        public string? PanelType { get; set; }
        public bool IsSmartTv { get; set; }
    }
}
