using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.Ram
{
    public class RamAddDto
    {
        [Required(ErrorMessage = "Ծավալը պարտադիր է")]
        public string Size { get; set; } = default!;
    }
}
