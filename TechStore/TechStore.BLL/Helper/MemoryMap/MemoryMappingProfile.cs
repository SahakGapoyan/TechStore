using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Memory;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.MemoryMap
{
    public class MemoryMappingProfile:Profile
    {
        public MemoryMappingProfile()
        {
            CreateMap<Memory, MemoryDto>();
            CreateMap<MemoryAddDto, Memory>();
        }
    }
}
