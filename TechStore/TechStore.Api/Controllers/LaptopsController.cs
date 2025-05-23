﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.BLL.DtoModels.Product;
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
        public async Task<ActionResult<LaptopDto>> GetLaptopById([FromRoute] int id, CancellationToken token)
        {
            var laptop = await _laptopService.GetProductById(id, token);

            if (laptop == null)
                return NotFound();

            return Ok(laptop);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLaptop([FromBody] LaptopAddDto laptopAddDto, CancellationToken token)
        {
            var result = await _laptopService.AddProduct(laptopAddDto, token);

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
        public async Task<ActionResult> UpdateLaptop([FromRoute] int id, [FromBody] LaptopUpdateDto laptopUpdateDto,
            CancellationToken token)
        {
            var result = await _laptopService.UpdateLaptop(id, laptopUpdateDto, token);

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
        public async Task<ActionResult> DeleteLaptop([FromRoute] int id, CancellationToken token)
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

            return Ok(result.Item2);
        }

        [HttpGet("memoryId/{memoryId}")]
        public async Task<ActionResult<List<LaptopDto>>> GetLaptopsByMemoryId(int memoryId, CancellationToken token = default)
        {
            var result = await _laptopService.GetLaptopsByMemoryId(memoryId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result.Item2);
        }
        [HttpGet("osId/{osId}")]
        public async Task<ActionResult<List<LaptopDto>>> GetLaptopsByOSID([FromRoute] int osId, CancellationToken token = default)
        {
            var result = await _laptopService.GetLaptopsByOSId(osId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result.Item2);
        }

        [HttpGet("colorId/{colorId}")]
        public async Task<ActionResult<List<LaptopDto>>> GetLaptopsByColorId([FromRoute] int colorId, CancellationToken token = default)
        {
            var result = await _laptopService.GetProductsByColorId(colorId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result.Item2);
        }

        [HttpGet("brandId/{brandId}")]
        public async Task<ActionResult<List<LaptopDto>>> GetLaptopsByBrandId([FromRoute] int brandId, CancellationToken token = default)
        {
            var result = await _laptopService.GetProductsByBrandId(brandId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result.Item2);
        }

        [HttpGet("modelId/{modelId}")]
        public async Task<ActionResult<List<LaptopDto>>> GetLaptopsByModelId([FromRoute] int modelId, CancellationToken token = default)
        {
            var result = await _laptopService.GetProductsByModelId(modelId, token);

            if (!result.Item1.Success)
            {
                if (result.Item1.ErrorType == ErrorType.NotFound)
                    return NotFound(result.Item1.Message);
            }

            return Ok(result.Item2);
        }

        [HttpGet("suggestions")]
        public async Task<ActionResult<List<LaptopDto>>> GetLaptopSuggestions([FromQuery] string query, CancellationToken token)
        {
            return Ok(await _laptopService.GetProductSuggestions(query, token));
        }
    }
}
