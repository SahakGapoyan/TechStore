using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.OS
{
    public class OSUpdateDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string? Name { get; set; }
    }
}
