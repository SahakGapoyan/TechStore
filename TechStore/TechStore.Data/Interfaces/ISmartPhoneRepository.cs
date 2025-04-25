using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface ISmartPhoneRepository : IProductRepository<SmartPhone>
    {
        Task<IEnumerable<SmartPhone>> GetSmartPhonesByRamId(int ramId, CancellationToken token = default);
        Task<IEnumerable<SmartPhone>> GetSmartPhonesByMemoryId(int memoryId, CancellationToken token = default);
        Task<IEnumerable<SmartPhone>> GetSmartPhonesByOSID(int oSId, CancellationToken token = default);
        Task<IEnumerable<SmartPhone>> GetSmartPhonesByColorId(int colorId, CancellationToken token = default);
    }
}
