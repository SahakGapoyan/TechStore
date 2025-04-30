using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.BLL.DtoModels.Tv;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TVsController : ControllerBase
    {
        private readonly ITvService _tvService;

        public TVsController(ITvService tvService)
        {
            _tvService = tvService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TvDto>>> GetTVs(CancellationToken token)
        {
            return Ok(await _tvService.GetProducts(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<TvDto>> GetTVById([FromRoute] int id, CancellationToken token)
        {
            var tv = await _tvService.GetProductById(id, token);

            if (tv == null)
                return NotFound();

            return Ok(tv);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTV([FromBody] TvAddDto tvAddDto, CancellationToken token)
        {
            await _tvService.AddProduct(tvAddDto, token);

            return Ok("Successfully created.");
        }

        [HttpPut("id/{id}")]
        public async Task<ActionResult> UpdateTV([FromRoute] int id, [FromBody] TvUpdateDto tvUpdateDto,
            CancellationToken token)
        {
            var result = await _tvService.UpdateTv(id, tvUpdateDto, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteTV([FromRoute] int id, CancellationToken token)
        {
            var result = await _tvService.DeleteProduct(id, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }

        [HttpGet("colorId/{colorId}")]
        public async Task<ActionResult<List<TvDto>>> GetTvsByColorId([FromRoute] int colorId, CancellationToken token = default)
        {
            var result = await _tvService.GetProductsByColorId(colorId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result.Item2);
        }

        [HttpGet("brandId/{brandId}")]
        public async Task<ActionResult<List<TvDto>>> GetTvsByBrandId([FromRoute] int brandId, CancellationToken token = default)
        {
            var result = await _tvService.GetProductsByBrandId(brandId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result.Item2);
        }

        [HttpGet("modelId/{modelId}")]
        public async Task<ActionResult<List<TvDto>>> GetTvsByModelId([FromRoute] int modelId, CancellationToken token = default)
        {
            var result = await _tvService.GetProductsByModelId(modelId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result.Item2);
        }
    }
}
