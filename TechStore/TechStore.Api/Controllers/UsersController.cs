using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Category;
using TechStore.BLL.DtoModels.Enums;
using TechStore.BLL.DtoModels.User;
using TechStore.BLL.Interfaces;
using TechStore.Data.Entity;

namespace TechStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers(CancellationToken token)
        {
            return Ok(await _userService.GetAll(token));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<UserDto>> GetUserById([FromRoute] int id, CancellationToken token)
        {
            var user = await _userService.GetById(id, token);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserAddDto userAddDto, CancellationToken token)
        {
            await _userService.AddUser(userAddDto);
            return Ok("Successfully created.");
        }

        [HttpPut("id/{id}")]
        public async Task<ActionResult> UpdateUser([FromRoute] int id, [FromBody] UserUpdateDto userUpdateDto, CancellationToken token)
        {
            var result = await _userService.UpdateUser(id, userUpdateDto, token);
            if (!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }
            return Ok(result.Message);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id, CancellationToken token)
        {
            var result = await _userService.DeleteUser(id, token);
            if(!result.Success)
            {
                if (result.ErrorType == ErrorType.NotFound)
                    return NotFound();
            }
            return Ok(result.Message);
        }
    }
}
