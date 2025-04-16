using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Product;
using TechStore.Data.Entity;

namespace TechStore.BLL.DtoModels.Laptop
{
    public class LaptopUpdateDto : ProductUpdateDto
    {
        public int? RamId { get; set; }
        public int? MemoryId { get; set; }
        public int? OsId { get; set; }
        public string? Processor { get; set; }
        public string? GPU { get; set; }
        public string? ScreenSize { get; set; }
        public int? BatteryLifeInHours { get; set; }
        public bool? HasTouchScreen { get; set; }
        public bool? HasFingerprintSensor { get; set; }
    }
}
