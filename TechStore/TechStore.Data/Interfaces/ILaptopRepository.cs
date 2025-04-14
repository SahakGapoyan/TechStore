using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface ILaptopRepository : IProductRepository<Laptop>
    {
        Task<IEnumerable<Laptop>> GetLaptopsByRamId(int ramId, CancellationToken token = default);
        Task<IEnumerable<Laptop>> GetLaptopsByMemoryId(int memoryId, CancellationToken token = default);
        Task<IEnumerable<Laptop>> GetLaptopsByOSId(int osId, CancellationToken token = default);
    }
}
