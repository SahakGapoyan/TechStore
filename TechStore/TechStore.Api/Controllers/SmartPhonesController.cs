using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartPhonesController : ControllerBase
    {
        private readonly ISmartPhoneService _smartPhoneService;

        public SmartPhonesController(ISmartPhoneService smartPhoneService)
        {
            _smartPhoneService = smartPhoneService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SmartPhoneDto>>> GetSmartPhones(CancellationToken token)
        {
            return Ok(await _smartPhoneService.GetProducts(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<SmartPhoneDto>> GetSmartPhoneById([FromRoute] int id, CancellationToken token)
        {
            var smartPhone = await _smartPhoneService.GetProductById(id, token);

            if (smartPhone == null)
                return NotFound();

            return Ok(smartPhone);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSmartPhone([FromBody] SmartPhoneAddDto smartPhoneAddDto, CancellationToken token)
        {
            await _smartPhoneService.AddProduct(smartPhoneAddDto, token);

            return Ok("Successfully created.");
        }

        [HttpPut("id/{id}")]
        public async Task<ActionResult> UpdateSmartPhone([FromRoute] int id, [FromBody] SmartPhoneUpdateDto smartPhoneUpdateDto,
            CancellationToken token)
        {
            var result = await _smartPhoneService.UpdateProduct(id, smartPhoneUpdateDto, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteSmartPhone([FromRoute] int id, CancellationToken token)
        {
            var result = await _smartPhoneService.DeleteProduct(id, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }

        [HttpGet("ramId/{ramId}")]
        public async Task<ActionResult<List<SmartPhoneDto>>> GetSmartPhonesByRamId([FromRoute] int ramId, CancellationToken token = default)
        {
            var result = await _smartPhoneService.GetSmartPhonesByRamId(ramId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result);
        }

        [HttpGet("memoryId/{memoryId}")]
        public async Task<ActionResult<List<SmartPhoneDto>>> GetSmartPhonesByMemoryId(int memoryId, CancellationToken token = default)
        {
            var result = await _smartPhoneService.GetSmartPhonesByMemoryId(memoryId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result);
        }
        [HttpGet("osId/{osId}")]
        public async Task<ActionResult<List<SmartPhoneDto>>> GetSmartPhonesByOSID([FromRoute] int osId, CancellationToken token = default)
        {
            var result = await _smartPhoneService.GetSmartPhonesByOSId(osId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result);
        }

        [HttpGet("colorId/{colorId}")]
        public async Task<ActionResult<List<SmartPhoneDto>>> GetSmartPhonesByColorId(int colorId, CancellationToken token = default)
        {
            var result = await _smartPhoneService.GetSmartPhonesByColorId(colorId,token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result);
        }
    }
}
