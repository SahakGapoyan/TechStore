using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Tv;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class TvService : ProductService<Tv, TvDto, TvAddDto, TvUpdateDto>, ITvService
    {
        public TvService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }
    }
}
