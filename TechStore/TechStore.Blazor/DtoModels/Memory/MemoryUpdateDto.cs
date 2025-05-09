using System.ComponentModel.DataAnnotations;
using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.Memory
{
    public class MemoryUpdateDto:BaseDto
    {
        [Required(ErrorMessage = "Ծավալը պարտադիր է")]
        public string? Size { get; set; }
    }
}
