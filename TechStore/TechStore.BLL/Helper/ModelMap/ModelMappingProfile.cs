using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Model;
using TechStore.Data.Entity;

namespace TechStore.BLL.Helper.ModelMap
{
    public class ModelMappingProfile:Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Model, ModelDto>();
            CreateMap<ModelAddDto, Model>();
        }
    }
}
