using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Tv;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class TvService : ProductService<Tv, TvDto, TvAddDto, TvUpdateDto>, ITvService
    {
        public TvService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }

        public async Task<Result> UpdateTv(int tvId, TvUpdateDto tvUpdateDto, CancellationToken token = default)
        {
            var result = await base.UpdateProduct(tvId, tvUpdateDto, token);
            if (!result.Success)
                return result;

            var tv = await _uow.TvRepository.GetProductById(tvId, token);

            tv.ScreenSize = tvUpdateDto.ScreenSize ?? tv.ScreenSize;
            tv.PanelType = tvUpdateDto.PanelType ?? tv.PanelType;
            tv.IsSmartTv = tvUpdateDto.IsSmartTv ?? tv.IsSmartTv;

            await _uow.TvRepository.UpdateProduct(tv);
            await _uow.SaveAsync(token);

            return Result.Ok("Successfully updated.");
        }
    }
}
