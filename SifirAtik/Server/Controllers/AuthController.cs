using SifirAtik.Domain.Dtos;
using SifirAtik.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SifirAtik.Server.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            return Ok(await _authService.RegisterAsync(registerUserDto));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            return Ok(await _authService.LoginAsync(loginUserDto));
        }

        [HttpPost("UpdatePassword"), Authorize]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            return Ok(await _authService.UpdatePasswordAsync(updatePasswordDto));
        }
    }
}
