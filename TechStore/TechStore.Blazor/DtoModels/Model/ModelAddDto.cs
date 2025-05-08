using System.ComponentModel.DataAnnotations;

namespace TechStore.Blazor.DtoModels.Model
{
    public class ModelAddDto
    {
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Տարեթիվը պարտադիր է")]
        [Range(2000, 2100, ErrorMessage = "Տարեթիվը պետք է լինի 2000-ից 2100։")]
        public int AnnouncementYear { get; set; }

        [Required(ErrorMessage ="Քանակը պարտադիր է")]
        [Range(1, int.MaxValue, ErrorMessage = "Մարտկոցի ծավալը պետք է լինի դրական")]
        public int Stock { get; set; }
    }
}
