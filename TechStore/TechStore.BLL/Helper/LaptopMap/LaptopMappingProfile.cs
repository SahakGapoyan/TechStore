using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.LaptopMap
{
    public class LaptopMappingProfile : Profile
    {
        public LaptopMappingProfile()
        {
            CreateMap<Laptop, LaptopDto>();
            CreateMap<LaptopAddDto, Laptop>();
        }
    }
}
