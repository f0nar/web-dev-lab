using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CountriesGame.Web.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authenticationService)
        {
            if (authenticationService == null)
                throw new ArgumentNullException(nameof(authenticationService));

            _authService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            var userId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId == null)
                return StatusCode(401);

            await _authService.ChangePasswordAsync(changePasswordDto, userId);
            await _authService.ConfirmPassword(userId);

            return Ok();
        }
    }
}