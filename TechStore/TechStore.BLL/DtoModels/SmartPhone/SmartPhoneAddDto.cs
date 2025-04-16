using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Product;
using TechStore.Data.Entity;

namespace TechStore.BLL.DtoModels.SmartPhone
{
    public class SmartPhoneAddDto:ProductAddDto
    {
        public int RamId { get; set; }
        public int MemoryId { get; set; }
        public int OSId { get; set; }
        public string ScreenSize { get; set; } = default!;
        public string Processor { get; set; } = default!;
        public int BatteryCapacity { get; set; }
        public int CameraMegaPixel { get; set; }
        public bool Has5G { get; set; }
        public bool IsWaterResistant { get; set; }
        public bool Wifi { get; set; }
    }
}
