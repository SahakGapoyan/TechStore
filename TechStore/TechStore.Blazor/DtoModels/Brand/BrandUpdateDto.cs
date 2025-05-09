using System.ComponentModel.DataAnnotations;
using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.Brand
{
    public class BrandUpdateDto:BaseDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string? Name { get; set; }
        public string? ImageUrl { get; set; } 
    }
}
