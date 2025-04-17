using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Color;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.ColorMap
{
    public class ColorMapping:Profile
    {
        public ColorMapping()
        {
            CreateMap<Color, ColorDto>();
            CreateMap<Color, ColorAddDto>().ReverseMap();
        }
    }
}
