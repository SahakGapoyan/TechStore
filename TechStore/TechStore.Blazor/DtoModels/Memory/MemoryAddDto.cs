using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.Memory
{
    public class MemoryAddDto
    {
        [Required(ErrorMessage ="Ծավալը պարտադիր է")]
        public string Size { get; set; } = default!;
    }
}
