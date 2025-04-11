using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class OS : BaseEntity
    {
        public string Size { get; set; } = default!;
        public IEnumerable<SmartPhone> SmartPhones { get; set; } = new List<SmartPhone>();
    }
}
