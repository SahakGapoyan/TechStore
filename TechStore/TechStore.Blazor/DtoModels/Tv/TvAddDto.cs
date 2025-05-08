using System.ComponentModel.DataAnnotations;
using TechStore.Blazor.DtoModels.Product;

namespace TechStore.Blazor.DtoModels.Tv
{
    public class TvAddDto:ProductAddDto
    {
        [Required(ErrorMessage = "Էկրանի չափսը պարտադիր է")]
        public string ScreenSize { get; set; }
        public string? PanelType { get; set; }
        public bool IsSmartTv { get; set; }
    }
}
