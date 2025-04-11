using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class SmartPhone : Product
    {
        public Ram Ram { get; set; } = default!;
        public int RamId { get; set; }
        public Memory Memory { get; set; } = default!;
        public int MemoryId { get; set; }
        public OS OS { get; set; } = default!;
        public int OSId { get; set; }
        public Color Color { get; set; } = default!;
        public int ColorId { get; set; }
        public string ScreenSize { get; set; } = default!;
        public string Processor { get; set; } = default!;
        public int BatteryCapacity { get; set; }
        public int CameraMegaPixel { get; set; }
        public bool Has5G { get; set; }
        public bool IsWaterResistant { get; set; }
        public bool Wifi { get; set; }
    }
}
