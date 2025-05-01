namespace TechStore.Blazor.DtoModels.Product
{
    public class ProductSuggestionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ProductType { get; set; } = default!;
    }
}
