using SifirAtik.Domain.Dtos;
using SifirAtik.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SifirAtik.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create"), Authorize(Roles = "Root")]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            return Ok(await _userService.CreateAsync(createUserDto));
        }

        [HttpGet("GetAll"), Authorize(Roles = "Root")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("GetById/{guid}")]
        public async Task<IActionResult> GetById(Guid guid)
        {
            return Ok(await _userService.GetByIdAsync(guid));
        }

        [HttpPost("Update"), Authorize(Roles = "Root")]
        public async Task<IActionResult> Update(UpdateUserProfileDto updateUserDto)
        {
            return Ok(await _userService.UpdateAsync(updateUserDto));
        }

        [HttpPost("UpdateUserProfile")]
        public async Task<IActionResult> UpdateUserProfile(UpdateUserProfileDto updateUserProfileDto)
        {
            return Ok(await _userService.UpdateAsync(updateUserProfileDto));
        }

        [HttpPost("UpdateEmail")]
        public async Task<IActionResult> UpdateEmail(UpdateEmailDto updateEmailDto)
        {
            return Ok(await _userService.UpdateAsync(updateEmailDto));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(DeleteUserDto deleteUserDto)
        {
            return Ok(await _userService.DeleteAsync(deleteUserDto));
        }
    }
}
