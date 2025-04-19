using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface ISmartPhoneService : IProductService<SmartPhone, SmartPhoneDto, SmartPhoneAddDto, SmartPhoneUpdateDto>
    {

    }
}
