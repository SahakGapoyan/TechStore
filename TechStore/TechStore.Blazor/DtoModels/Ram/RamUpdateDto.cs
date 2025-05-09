using System.ComponentModel.DataAnnotations;
using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.Ram
{
    public class RamUpdateDto:BaseDto
    {
        [Required(ErrorMessage = "Ծավալը պարտադիր է")]
        public string? Size { get; set; }
    }
}
