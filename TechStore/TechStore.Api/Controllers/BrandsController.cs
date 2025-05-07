using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TechStore.BLL.DtoModels.Brand;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.Interfaces;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BrandDto>>> GetBrands(CancellationToken token)
        {
            return Ok(await _brandService.GetBrands(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<BrandDto>> GetBrandById([FromRoute] int id, CancellationToken token)
        {
            var brand = await _brandService.GetBrand(id, token);

            if (brand == null)
                return NotFound();

            return Ok(brand);
        }

        [HttpGet("categoryId/{categoryId}")]
        public async Task<ActionResult<BrandDto>> GetBrandsByCategoryId([FromRoute] int categoryId, CancellationToken token)
        {
            return Ok(await _brandService.GetBrandsByCategoryId(categoryId, token));
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrand(BrandAddDto brandAddDto, CancellationToken token)
        {
            var result = await _brandService.AddBrand(brandAddDto, token);

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
        public async Task<ActionResult> UpdateBrand([FromRoute] int id, [FromBody] BrandUpdateDto brandUpdateDto, CancellationToken token)
        {
            var result = await _brandService.UpdateBrand(id, brandUpdateDto, token);

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
        public async Task<ActionResult> DeleteBrand([FromRoute] int id, CancellationToken token)
        {
            var result = await _brandService.DeleteBrand(id, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }

    }
}
