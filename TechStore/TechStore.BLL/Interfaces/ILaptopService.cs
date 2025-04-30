using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface ILaptopService : IProductService<Laptop, LaptopDto, LaptopAddDto, LaptopUpdateDto>
    {
        Task<(Result, IEnumerable<LaptopDto>)> GetLaptopsByRamId(int ramId, CancellationToken token = default);
        Task<(Result, IEnumerable<LaptopDto>)> GetLaptopsByMemoryId(int memoryId, CancellationToken token = default);
        Task<(Result, IEnumerable<LaptopDto>)> GetLaptopsByOSId(int osId, CancellationToken token = default);
        Task<Result> UpdateLaptop(int laptopId, LaptopUpdateDto laptopUpdateDto, CancellationToken token = default);

    }
}
