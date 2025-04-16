using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Tv;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface ITvService : IProductService<Tv, TvDto, TvAddDto, TvUpdatedto>
    {

    }
}
