using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.OS;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.OSMap
{
    public class OSMappingProfile : Profile
    {
        public OSMappingProfile()
        {
            CreateMap<OS, OSDto>();
            CreateMap<OSAddDto, OS>();
        }
    }
}
