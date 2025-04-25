using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.Memory
{
    public class MemoryDto:BaseDto  
    {
        public string Size { get; set; } = default!;
    }
}
