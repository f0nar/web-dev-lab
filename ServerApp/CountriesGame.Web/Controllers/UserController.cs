using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CountriesGame.Web.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            if (userService == null)
                throw new ArgumentNullException(nameof(userService));
            if (authService == null)
                throw new ArgumentNullException(nameof(authService));

            _userService = userService;
            _authService = authService;
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "Lecturer, Student")]
        public async Task<ActionResult<UserDto>> GetUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("The userId parameter is required.");

            var currentUserId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (currentUserId == userId ||
                await _authService.IsInRoleAsync(currentUserId, "Lecturer"))
            {
                var user = await _userService.GetUserAsync(userId);
                if (user == null)
                    return NotFound();

                return user;
            }
            return Forbid();
        }

        [HttpGet]
        [Authorize(Roles = "Lecturer")]
        public async Task<ActionResult<List<UserDto>>> GetUserByHeadId()
        {
            var headId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (headId == null)
                return StatusCode(401);

            var users = await _userService.GetUsersByHeadIdAsync(headId);
            return users.ToList();
        }

        [HttpPost]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> AddUser(RegisterDto registerDto)
        {
            var headId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (headId == null)
                return StatusCode(401);

            var user = await _authService.RegisterAsync(registerDto, headId);

            if (user == null)
                return BadRequest();

            return CreatedAtAction("GetUser",
                new { controller = "User", userId = user.Id }, user);
        }
    }
}