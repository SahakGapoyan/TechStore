using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.Color
{
    public class ColorUpdateDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Գույնի կոդը պարտադիր է")]
        public string? HexCode { get; set; }
    }
}
