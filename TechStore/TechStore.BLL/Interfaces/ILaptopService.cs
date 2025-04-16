using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface ILaptopService : IProductService<Laptop, LaptopDto, LaptopAddDto, LaptopUpdateDto>
    {
        Task<IEnumerable<LaptopDto>> GetLaptopsByRamId(int ramId, CancellationToken token = default);
        Task<IEnumerable<LaptopDto>> GetLaptopsByMemoryId(int memoryId, CancellationToken token = default);
        Task<IEnumerable<LaptopDto>> GetLaptopsByOSId(int osId, CancellationToken token = default);
    }
}
