using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Data.Interfaces
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetModels(CancellationToken token = default);
        Task<Model?> GetModel(int modelId, CancellationToken token = default);
        Task AddModel(Model model, CancellationToken token = default);
        Task Update(Model model);
        Task Delete(Model model);
    }
}
