﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Base;

namespace TechStore.BLL.DtoModels.Brand
{
    public class BrandUpdateDto:BaseDto
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
    }

}
