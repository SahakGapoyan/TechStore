using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Model;
using TechStore.BLL.Interfaces;

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
        public async Task<ActionResult<ModelDto>> GetModel([FromRoute] int id,CancellationToken token)
        {
            var model = await _modelService.GetModel(id, token);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateModel([FromBody] ModelAddDto modelAddDto, CancellationToken token)
        {
            await _modelService.AddModel(modelAddDto, token);
            return Ok("Successfully Created");
        }

        [HttpPut("id/{id}")]
        public async Task<ActionResult> UpdateModel([FromRoute] int id, [FromBody] ModelUpdateDto modelUpdateDto,CancellationToken token)
        {
            var result = await _modelService.Update(id, modelUpdateDto, token);
            if(!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
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
