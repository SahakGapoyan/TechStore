using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Brand;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandAddDto, Brand>();
        }
    }
}
