using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Tv;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.TvMap
{
    public class TvMappingProfile : Profile
    {
        public TvMappingProfile()
        {
            CreateMap<Tv, TvDto>();
            CreateMap<TvAddDto, Tv>();
        }
    }
}
