using TechStore.Blazor.DtoModels.Product;

namespace TechStore.Blazor.DtoModels.Laptop
{
    public class LaptopAddDto : ProductAddDto
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
