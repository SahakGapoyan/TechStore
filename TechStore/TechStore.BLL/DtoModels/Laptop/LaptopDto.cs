using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Product;
using TechStore.Data.Entity;

namespace TechStore.BLL.DtoModels.Laptop
{
    public class LaptopDto : ProductDto
    {
        public int RamId { get; set; }
        public int MemoryId { get; set; }
        public int OsId { get; set; }
        public string Processor { get; set; } = default!;
        public string GPU { get; set; } = default!;
        public string ScreenSize { get; set; } = default!;
        public int BatteryLifeInHours { get; set; }
        public bool HasTouchScreen { get; set; }
        public bool HasFingerprintSensor { get; set; }
    }
}
