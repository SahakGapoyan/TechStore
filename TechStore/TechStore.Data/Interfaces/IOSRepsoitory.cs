using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface IOSRepsoitory
    {
        Task<IEnumerable<OS>> GetOSs(CancellationToken token=default);
        Task<OS?> GetOSById(int osId, CancellationToken token=default);
        Task<IEnumerable<OS>> GetOsesByCategoryId(int categoryId, CancellationToken token = default);
        Task AddOS(OS oS, CancellationToken token = default);
        Task UpdateOS(OS oS);
        Task DeleteOS(OS oS);
    }
}
