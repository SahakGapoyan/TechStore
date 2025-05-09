using System.ComponentModel.DataAnnotations;
using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.OS
{
    public class OSUpdateDto:BaseDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string? Name { get; set; }
    }
}
