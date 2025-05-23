﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.BLL.DtoModels.Color;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.Memory;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ColorDto>>> GetColors(CancellationToken token)
        {
            return Ok(await _colorService.GetColors(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ColorDto>> GetColorById([FromRoute] int id, CancellationToken token)
        {
            var color = await _colorService.GetColorById(id, token);

            if (color == null)
                return NotFound();

            return Ok(color);
        }

        [HttpGet("categoryId/{categoryId}")]
        public async Task<ActionResult<ColorDto>> GetColorsByCategoryId([FromRoute] int categoryId, CancellationToken token)
        {
            return Ok(await _colorService.GetColorsByCategoryId(categoryId, token));
        }

        [HttpPost]
        public async Task<ActionResult> CreateColor([FromBody] ColorAddDto colorAddDto, CancellationToken token)
        {
            var result = await _colorService.AddColor(colorAddDto, token);

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
        public async Task<ActionResult> UpdateColor([FromRoute] int id, [FromBody] ColorUpdateDto colorUpdateDto,
            CancellationToken token)
        {
            var result = await _colorService.UpdateColor(id, colorUpdateDto, token);

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
        public async Task<ActionResult> DeleteColor([FromRoute] int id, CancellationToken token)
        {
            var result = await _colorService.DeleteColor(id, token);

            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }

            return Ok(result.Message);
        }
    }
}
