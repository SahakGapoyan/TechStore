using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface IRamRepository
    {
        Task<IEnumerable<Ram>> GetRams(CancellationToken token=default);
        Task<Ram?> GetRamById(int ramId, CancellationToken token = default);
        Task<IEnumerable<Ram>> GetRamsByCategoryId(int categoryId, CancellationToken token = default);
        Task AddRam(Ram ram, CancellationToken token = default);
        Task UpdateRam(Ram ram);
        Task DeleteRam(Ram ram);
    }
}
