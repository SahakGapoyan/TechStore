using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.Product
{
    public class ProductAddDto
    {
        [Required(ErrorMessage ="Անունը պարտադիր է")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Գինը պարտադիր է։")]
        [Range(1,2000000,ErrorMessage = "Գինը պետք է լինի 1֊ից 1,000,000 միջակայքում։")]
        public decimal Price { get; set; }

        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        [Required(ErrorMessage = "Կատեգորիան պարտադիր է")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Բրենդը պարտադիր է")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Մոդելը պարտադիր է")]
        public int ModelId { get; set; }
        [Required(ErrorMessage = "Գույնը պարտադիր է")]
        public int ColorId { get; set; }
        public List<string> ImagesUrls { get; set; } = new List<string>();
    }
}
