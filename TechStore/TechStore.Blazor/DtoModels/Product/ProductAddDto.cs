namespace TechStore.Blazor.DtoModels.Product
{
    public class ProductAddDto
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public List<string> ImagesUrls { get; set; } = new List<string>();
    }
}
