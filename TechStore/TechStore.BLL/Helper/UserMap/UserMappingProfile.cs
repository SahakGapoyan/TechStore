using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.User;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.UserMap
{
    class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserAddDto>().ReverseMap();
        }
    }
}
