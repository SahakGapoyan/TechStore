using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels.Brand;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Memory;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoriesController : ControllerBase
    {
        private readonly IMemoryService _memoryService;

        public MemoriesController(IMemoryService memoryService)
        {
            _memoryService = memoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MemoryDto>>> GetMemories(CancellationToken token)
        {
            return Ok(await _memoryService.GetMemories(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<MemoryDto>> GetMemoryById([FromRoute] int id, CancellationToken token)
        {
            var memory = await _memoryService.GetMemoryById(id, token);

            if (memory == null)
                return NotFound();

            return Ok(memory);
        }

        [HttpGet("categoryId/{categoryId}")]
        public async Task<ActionResult<MemoryDto>> GetMemoriesByCategoryId([FromRoute] int categoryId, CancellationToken token)
        {
            return Ok(await _memoryService.GetMemoriesByCategoryId(categoryId, token));
        }

        [HttpPost]
        public async Task<ActionResult> CreateMemory([FromBody] MemoryAddDto memoryAddDto, CancellationToken token)
        {
            var result = await _memoryService.AddMemory(memoryAddDto, token);

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
        public async Task<ActionResult> UpdateMemory([FromRoute] int id, [FromBody] MemoryUpdateDto memoryUpdateDto,
            CancellationToken token)
        {
            var result = await _memoryService.UpdateMemory(id, memoryUpdateDto, token);

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
        public async Task<ActionResult> DeleteMemory([FromRoute] int id, CancellationToken token)
        {
            var result = await _memoryService.DeleteMemory(id, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }
    }
}
