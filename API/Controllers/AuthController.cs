using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Models.Auth;
using API.Services.Interfaces;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var response = await _userService.VerifyUserAsync(request);
            if (response == null)
                return Unauthorized(new { message = "Invalid login or password" });

            return Ok(response);
        }

        [HttpGet("verify-role")]
        [Authorize]
        public ActionResult<object> VerifyRole()
        {
            var roleClaim = User.FindFirst(ClaimTypes.Role);
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userNameClaim = User.FindFirst(ClaimTypes.Name);
            var schoolIdClaim = User.FindFirst("SchoolId");

            return Ok(new
            {
                Role = roleClaim?.Value,
                UserId = userIdClaim?.Value,
                UserName = userNameClaim?.Value,
                SchoolId = schoolIdClaim?.Value,
                AllClaims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }
    }
}