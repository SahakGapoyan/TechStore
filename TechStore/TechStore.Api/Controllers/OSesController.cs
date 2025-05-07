using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.OS;
using TechStore.BLL.DtoModels.Ram;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OSesController : ControllerBase
    {
        private readonly IOSService _oSService;

        public OSesController(IOSService oSService)
        {
            _oSService = oSService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OSDto>>> GetOSes(CancellationToken token)
        {
            return Ok(await _oSService.GetOSs(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<OSDto>> GetOSById([FromRoute] int id, CancellationToken token)
        {
            var OS = await _oSService.GetOSById(id, token);
            if (OS == null)
            {
                return NotFound();
            }
            return Ok(OS);
        }

        [HttpGet("categoryId/{categoryId}")]
        public async Task<ActionResult<OSDto>> GetOsesByCategoryId([FromRoute] int categoryId, CancellationToken token)
        {
            return Ok(await _oSService.GetOsesByCategoryId(categoryId, token));
        }

        [HttpPost]
        public async Task<ActionResult> CreateOS([FromBody] OSAddDto oSAddDto, CancellationToken token)
        {
            var result = await _oSService.AddOS(oSAddDto, token);

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

        [HttpPut("id/{id}")]
        public async Task<ActionResult> UpdateOS([FromRoute] int id, [FromBody] OSUpdateDto oSUpdateDto, CancellationToken token)
        {
            var result = await _oSService.UpdateOS(id, oSUpdateDto, token);

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

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteOS([FromRoute] int id, CancellationToken token)
        {
            var result = await _oSService.DeleteOS(id, token);
            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }
            return Ok(result.Message);
        }
    }
}
