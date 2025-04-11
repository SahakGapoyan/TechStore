using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class SmartPhone:Product
    {
        public Ram Ram { get; set; } = default!;
        public int RamId { get; set; }
        public string OperatingSystem { get; set; } = default!;
        public string ScreenSize { get; set; } = default!;
        public string Processor { get; set; } = default!;
        public int BatteryCapacity { get; set; }
        public int CameraMegaPixel { get; set; }
        public bool Has5G { get; set; }
        public bool IsWaterResistant { get; set; }
        public bool Wifi { get; set; }
    }
}
