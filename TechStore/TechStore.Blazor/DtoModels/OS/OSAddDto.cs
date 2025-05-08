using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.OS
{
    public class OSAddDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string Name { get; set; } = default!;
    }
}
