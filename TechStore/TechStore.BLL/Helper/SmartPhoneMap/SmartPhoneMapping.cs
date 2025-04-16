using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.SmartPhoneMap
{
    public class SmartPhoneMapping:Profile
    {
        public SmartPhoneMapping()
        {
            CreateMap<SmartPhone, SmartPhoneDto>();
            CreateMap<SmartPhone, SmartPhoneAddDto>().ReverseMap();
        }
    }
}
