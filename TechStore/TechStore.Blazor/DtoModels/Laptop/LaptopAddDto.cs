using System.ComponentModel.DataAnnotations;
using TechStore.Blazor.DtoModels.Product;

namespace TechStore.Blazor.DtoModels.Laptop
{
    public class LaptopAddDto : ProductAddDto
    {
        [Required(ErrorMessage = "Ռամը պարտադիր է")]
        public int RamId { get; set; }
        [Required(ErrorMessage = "Հիշողությունը պարտադիր է")]
        public int MemoryId { get; set; }
        [Required(ErrorMessage = "Օպերացիոն համակարգը պարտադիր է")]
        public int OsId { get; set; }
        [Required(ErrorMessage = "Պրոցեսորը պարտադիր է")]
        public string Processor { get; set; } = default!;
        [Required(ErrorMessage = "Գրաֆիկական պրոցեսորը պարտադիր է")]
        public string GPU { get; set; } = default!;
        [Required(ErrorMessage = "Էկրանի չափսը պարտադիր է")]
        public string ScreenSize { get; set; } = default!;
        [Range(1, int.MaxValue, ErrorMessage = "Մարտկոցի կյանքի տևողությունը պետք է լինի դրական")]
        public int BatteryLifeInHours { get; set; }
        public bool HasTouchScreen { get; set; }
        public bool HasFingerprintSensor { get; set; }
    }
}
