using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class Color : BaseEntity
    {
        public string Name { get; set; } = default!;
    }
}
