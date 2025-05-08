using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.Memory
{
    public class MemoryUpdateDto
    {
        [Required(ErrorMessage = "Ծավալը պարտադիր է")]
        public string? Size { get; set; }
    }
}
