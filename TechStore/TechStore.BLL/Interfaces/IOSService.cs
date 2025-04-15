using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.OS;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface IOSService
    {
        Task<IEnumerable<OSDto>> GetOSs(CancellationToken token = default);
        Task<OSDto?> GetOSById(int osId, CancellationToken token = default);
        Task AddOS(OSAddDto oSAddDto, CancellationToken token = default);
        Task<Result> UpdateOS(int OsId, OSUpdateDto oSUpdateDto, CancellationToken token);
        Task<Result> DeleteOS(int OsId,  CancellationToken token);
    }
}
