using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Category;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.Interfaces;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories(CancellationToken token)
        {
            return Ok(await _categoryService.GetCategories(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById([FromRoute] int id, CancellationToken token)
        {
            var category = await _categoryService.GetCategory(id, token);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryAddDto categoryAddDto, CancellationToken token)
        {
            await _categoryService.AddCategory(categoryAddDto, token);
            return Ok("Successfully created.");
        }

        [HttpPut("id/{id}")]
        public async Task<ActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryUpdateDto categoryUpdateDto, CancellationToken token)
        {
            var result = await _categoryService.UpdateCategory(id, categoryUpdateDto, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteCategory([FromRoute] int id,CancellationToken token)
        {
            var result = await _categoryService.DeleteCategory(id, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }
    }
}
