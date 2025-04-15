using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Brand;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.BrandMap
{
    public class BrandMappingProfiles:Profile
    {
        public BrandMappingProfiles()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandAddDto, Brand>();
        }
    }
}
