using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface ISmartPhoneService : IProductService<SmartPhone, SmartPhoneDto, SmartPhoneAddDto, SmartPhoneUpdateDto>
    {
        Task<(Result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByRamId(int ramId, CancellationToken token = default);
        Task<(Result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByMemoryId(int memoryId, CancellationToken token = default);
        Task<(Result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByOSId(int osId, CancellationToken token = default);
        Task<Result> UpdateSmartPhone(int smartPhoneId, SmartPhoneUpdateDto smartPhoneUpdateDto, CancellationToken token = default);
    }
}
