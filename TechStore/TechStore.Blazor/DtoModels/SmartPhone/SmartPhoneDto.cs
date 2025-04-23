using TechStore.Blazor.DtoModels.Product;

namespace TechStore.Blazor.DtoModels.SmartPhone
{
    public class SmartPhoneDto:ProductDto 
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
