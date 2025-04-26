using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.Model
{
    public class ModelDto:BaseDto
    {
        public string Name { get; set; } = default!;
        public int AnnouncementYear { get; set; }
        public int Stock { get; set; }
    }
}
