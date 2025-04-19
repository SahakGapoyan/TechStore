using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;
using TechStore.Data.Interfaces;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopsController : ControllerBase
    {
        private readonly ILaptopService _laptopService;

        public LaptopsController(ILaptopService laptopService)
        {
            _laptopService = laptopService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LaptopDto>>> GetLaptops(CancellationToken token)
        {
            return Ok(await _laptopService.GetProducts(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<LaptopDto>> GetSmartPhoneById([FromRoute] int id, CancellationToken token)
        {
            var laptop = await _laptopService.GetProductById(id, token);

            if (laptop == null)
                return NotFound();

            return Ok(laptop);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLaptop([FromBody] LaptopAddDto laptopAddDto, CancellationToken token)
        {
            await _laptopService.AddProduct(laptopAddDto, token);

            return Ok("Successfully created.");
        }

        [HttpPut("id/{id}")]
        public async Task<ActionResult> UpdateLaptop([FromRoute] int id, [FromBody] LaptopUpdateDto laptopUpdateDto,
            CancellationToken token)
        {
            var result = await _laptopService.UpdateProduct(id, laptopUpdateDto, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var result = await _laptopService.DeleteProduct(id, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }

        [HttpGet("ramId/{ramId}")]
        public async Task<ActionResult<List<LaptopDto>>> GetLaptopsByRamId([FromRoute] int ramId, CancellationToken token = default)
        {
            var result = await _laptopService.GetLaptopsByRamId(ramId, token);

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
            var result = await _laptopService.GetLaptopsByMemoryId(memoryId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result);
        }
        [HttpGet("osId/{osId}")]
        public async Task<ActionResult<List<LaptopDto>>> GetSmartPhonesByOSID([FromRoute] int osId, CancellationToken token = default)
        {
            var result = await _laptopService.GetLaptopsByOSId(osId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result);
        }
    }
}
