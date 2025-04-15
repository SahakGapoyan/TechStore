using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Ram;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.RamMap
{
    public class RamMappingProfile:Profile
    {
        public RamMappingProfile()
        {
            CreateMap<Ram, RamDto>();
            CreateMap<Ram, RamAddDto>().ReverseMap();
        }
    }
}
