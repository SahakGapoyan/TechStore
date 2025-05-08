using System.ComponentModel.DataAnnotations;
using TechStore.Blazor.DtoModels.Product;

namespace TechStore.Blazor.DtoModels.SmartPhone
{
    public class SmartPhoneUpdateDto:ProductUpdateDto   
    {
        [Required(ErrorMessage = "Ռամը պարտադիր է")]
        public int? RamId { get; set; }
        [Required(ErrorMessage = "Հիշողությունը պարտադիր է")]
        public int? MemoryId { get; set; }
        [Required(ErrorMessage = "Օպերացիոն համակարգը պարտադիր է")]
        public int? OSId { get; set; }
        [Required(ErrorMessage = "Էկրանի չափսը պարտադիր է")]
        public string? ScreenSize { get; set; } = default!;
        [Required(ErrorMessage = "Պրոցեսորը պարտադիր է")]
        public string? Processor { get; set; } = default!;
        [Range(1, int.MaxValue, ErrorMessage = "Մարտկոցի ծավալը պետք է լինի դրական")]
        public int? BatteryCapacity { get; set; }
        [Range(0, 1000, ErrorMessage = "Մեգապիքսելների քանակը սխալ է")]
        public int? CameraMegaPixel { get; set; }
        public bool? Has5G { get; set; }
        public bool? IsWaterResistant { get; set; }
        public bool? Wifi { get; set; }
    }
}
