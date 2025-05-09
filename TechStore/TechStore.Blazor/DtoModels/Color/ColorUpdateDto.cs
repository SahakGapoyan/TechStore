using System.ComponentModel.DataAnnotations;
using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.Color
{
    public class ColorUpdateDto:BaseDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Գույնի կոդը պարտադիր է")]
        public string? HexCode { get; set; }
    }
}
