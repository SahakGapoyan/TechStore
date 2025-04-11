using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class Model:BaseEntity
    {
        public string Name { get; set; } = default!;
        public int AnnouncementYear { get; set; }
        public int Stock { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
