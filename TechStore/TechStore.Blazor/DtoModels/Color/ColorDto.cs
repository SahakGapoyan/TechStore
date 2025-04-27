using TechStore.Blazor.DtoModels.Base;

namespace TechStore.Blazor.DtoModels.Color
{
    public class ColorDto:BaseDto
    {
        public string Name { get; set; } = default!;
        public string HexCode { get; set; }= default!;
    }
}
