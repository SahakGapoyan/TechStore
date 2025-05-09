using System.ComponentModel.DataAnnotations;
using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.Category
{
    public class CategoryUpdateDto:BaseDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
