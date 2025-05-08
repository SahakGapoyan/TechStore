using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.Brand
{
    public class BrandUpdateDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string? Name { get; set; }
        public string? ImageUrl { get; set; } 
    }
}
