using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.Brand
{
    public class BrandAddDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Նկարի հղումը պարտադիր է")]
        public string ImageUrl { get; set; } = default!;
    }
}
