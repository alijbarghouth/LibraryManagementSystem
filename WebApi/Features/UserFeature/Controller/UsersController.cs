using Application.Features.UserFeature.Command;
using Domain.Features.UserService.DTOs;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Features.UserFeature.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class UsersController : ControllerBase
    {
        private readonly ICommandService _commandService;

        public UsersController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            return Ok(await _commandService.RegisterUser(user));
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginRequest request)
        {
            var (token, refreshToken) = await _commandService.LoginUser(request);
            if (!string.IsNullOrEmpty(refreshToken))
            {
                SetRefreshTokenInCookie(refreshToken);
            }
            return Ok(token);
        }
        [HttpPost("role")]
        public async Task<IActionResult> AddRole(RoleRequest roleRequest)
        {
            return Ok(await _commandService.AddRole(roleRequest));
        }
        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(3),
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
