using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.Category
{
    public class CategoryUpdateDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
