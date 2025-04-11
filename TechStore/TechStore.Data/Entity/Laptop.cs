using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class Laptop:Product
    {
        public Ram Ram { get; set; } = default!;
        public int RamId { get; set; }
        public string Processor { get; set; } = default!;
        public string GPU { get; set; } = default!;
        public string ScreenSize { get; set; } = default!;
        public int BatteryLifeInHours { get; set; }
        public bool HasTouchScreen { get; set; }
        public bool HasFingerprintSencor { get; set; }

    }
}
