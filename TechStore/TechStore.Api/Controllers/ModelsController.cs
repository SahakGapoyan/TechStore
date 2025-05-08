using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Model;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ModelDto>>> GetModels(CancellationToken token)
        {
            return Ok(await _modelService.GetModels(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ModelDto>> GetModel([FromRoute] int id, CancellationToken token)
        {
            var model = await _modelService.GetModel(id, token);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("categoryId/{categoryId}")]
        public async Task<ActionResult<ModelDto>> GetModelsByCategoryId([FromRoute] int categoryId, CancellationToken token)
        {
            return Ok(await _modelService.GetModelsByCategoryId(categoryId, token));
        }

        [HttpPost]
        public async Task<ActionResult> CreateModel([FromBody] ModelAddDto modelAddDto, CancellationToken token)
        {
            var result = await _modelService.AddModel(modelAddDto, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.Validation)
                    return BadRequest(new
                    {
                        errors = result.ValidationErrors.Select(e => new { e.PropertyName, e.ErrorMessage })
                    });
            }

            return Ok(result.Message);
        }

        [HttpPut("id/{id}")]
        public async Task<ActionResult> UpdateModel([FromRoute] int id, [FromBody] ModelUpdateDto modelUpdateDto, CancellationToken token)
        {
            var result = await _modelService.UpdateModel(id, modelUpdateDto, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();

                if (result.ErrorType == ErrorType.Validation)
                    return BadRequest(new
                    {
                        errors = result.ValidationErrors.Select(e => new { e.PropertyName, e.ErrorMessage })
                    });
            }

            return Ok(result.Message);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteModel([FromRoute] int id, CancellationToken token)
        {
            var result = await _modelService.Delete(id, token);
            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }
            return Ok(result.Message);
        }
    }
}
