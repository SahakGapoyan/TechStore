using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Entity
{
    public class Tv : Product
    {
        public string ScreenSize { get; set; }
        public string? PanelType { get; set; }
        public bool IsSmartTv { get; set; }
    }
}
