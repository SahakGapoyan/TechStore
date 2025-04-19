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
        Task<(Result result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByRamId(int ramId, CancellationToken token = default);
        Task<(Result result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByMemoryId(int memoryId, CancellationToken token = default);
        Task<(Result result, IEnumerable<SmartPhoneDto>)> GetSmartPhonesByOSID(int OSId, CancellationToken token = default);
    }
}
