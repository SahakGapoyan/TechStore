using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class Memory : BaseEntity
    {
        public string Size { get; set; } = default!;
    }
}
