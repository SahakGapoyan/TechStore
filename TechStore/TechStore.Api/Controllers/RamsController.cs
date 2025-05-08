using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Model;
using TechStore.BLL.DtoModels.Ram;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamsController : ControllerBase
    {
        private readonly IRamService _ramService;

        public RamsController(IRamService ramService)
        {
            _ramService = ramService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RamDto>>> GetRams(CancellationToken token)
        {
            return Ok(await _ramService.GetRams(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<RamDto>> GetRamById([FromRoute] int id, CancellationToken token)
        {
            var ram = await _ramService.GetRamById(id, token);
            if (ram == null)
            {
                return NotFound();
            }
            return Ok(ram);
        }

        [HttpGet("categoryId/{categoryId}")]
        public async Task<ActionResult<RamDto>> GetRamsByCategoryId([FromRoute] int categoryId, CancellationToken token)
        {
            return Ok(await _ramService.GetRamsByCategoryId(categoryId, token));
        }

        [HttpPost]
        public async Task<ActionResult> CreateRam([FromBody] RamAddDto ramAddDto, CancellationToken token)
        {
            var result = await _ramService.AddRam(ramAddDto, token);

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
        public async Task<ActionResult> UpdateRam([FromRoute] int id, [FromBody] RamUpdateDto ramUpdateDto, CancellationToken token)
        {
            var result = await _ramService.UpdateRam(id, ramUpdateDto, token);

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
        public async Task<ActionResult> DeleteRam([FromRoute] int id, CancellationToken token)
        {
            var result = await _ramService.DeleteRam(id, token);
            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }
            return Ok(result.Message);
        }
    }
}
