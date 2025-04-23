namespace TechStore.Blazor.DtoModels.Category
{
    public class CategoryAddDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
