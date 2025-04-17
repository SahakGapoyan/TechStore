using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BLL.DtoModels.Model
{
    public class ModelUpdateDto
    {
        public string? Name { get; set; }
        public int? AnnouncementYear { get; set; }
        public int? Stock { get; set; }
    }
}
