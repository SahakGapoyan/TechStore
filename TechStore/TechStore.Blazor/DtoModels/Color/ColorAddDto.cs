using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.Color
{
    public class ColorAddDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Գույնի կոդը պարտադիր է")]
        public string HexCode { get; set; } = default!;
    }
}
