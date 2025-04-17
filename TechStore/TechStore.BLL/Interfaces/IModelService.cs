using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Model;

namespace TechStore.BLL.Interfaces
{
    public interface IModelService
    {
        Task<IEnumerable<ModelDto>> GetModels(CancellationToken token = default);
        Task<ModelDto?> GetModel(int modelId, CancellationToken token = default);
        Task AddModel(ModelAddto modelAddDto, CancellationToken token = default);
        Task<Result> Update(int modelId, ModelUpdateDto modelUpdateDto, CancellationToken token = default);
        Task<Result> Delete(int modelId, CancellationToken token = default);
    }
}
