using TechStore.Blazor.DtoModels.Product;

namespace TechStore.Blazor.DtoModels.Tv
{
    public class TvDto:ProductDto
    {
        public string ScreenSize { get; set; }
        public string? PanelType { get; set; }
        public bool IsSmartTv { get; set; }
    }
}
