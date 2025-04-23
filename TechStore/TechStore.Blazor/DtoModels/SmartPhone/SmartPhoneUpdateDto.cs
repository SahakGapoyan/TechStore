using TechStore.Blazor.DtoModels.Product;

namespace TechStore.Blazor.DtoModels.SmartPhone
{
    public class SmartPhoneUpdateDto:ProductUpdateDto   
    {
        public int? RamId { get; set; }
        public int? MemoryId { get; set; }
        public int? OSId { get; set; }
        public string? ScreenSize { get; set; }
        public string? Processor { get; set; }
        public int? BatteryCapacity { get; set; }
        public int? CameraMegaPixel { get; set; }
        public bool? Has5G { get; set; }
        public bool? IsWaterResistant { get; set; }
        public bool? Wifi { get; set; }
    }
}
