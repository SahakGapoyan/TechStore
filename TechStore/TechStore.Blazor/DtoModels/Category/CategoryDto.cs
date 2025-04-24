using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.Category
{
    public class CategoryDto:BaseDto
    {
        public string Name { get; set; } = default!;
        public string Icon { get; set; } // Add icon property
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
