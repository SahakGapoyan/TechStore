using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.Brand
{
    public class BrandDto : BaseDto
    {
        public string Name { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
