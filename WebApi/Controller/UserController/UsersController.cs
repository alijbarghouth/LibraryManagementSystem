using Application.Authentication;
using Application.Command.UserCommand;
using Application.Handler.UserHandler.LoginHandler;
using Application.Handler.UserHandler.RefreshTokenHandler;
using Application.Handler.UserHandler.RegisterHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Primitives;
using WebApi.Filter;

namespace WebApi.Controller.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class UsersController : ControllerBase
    {
        private readonly IRegisterUserCommandHandler _registerCommandHandler;
        private readonly ILoginUserCommandHandler _loginUserCommandHandler;
        private readonly IRefreshTokenQueryHandler _refreshTokenQueryHandler;
        private readonly IDistributedCache _distributedCache;
        private readonly ILogoutService _logoutService;
        public UsersController(IRegisterUserCommandHandler registerCommandHandler,
              ILoginUserCommandHandler loginUserCommandHandler,
              IRefreshTokenQueryHandler refreshTokenQueryHandler,
              ILogoutService logoutService,
              IDistributedCache distributedCache)
        {
            _registerCommandHandler = registerCommandHandler;
            _loginUserCommandHandler = loginUserCommandHandler;
            _refreshTokenQueryHandler = refreshTokenQueryHandler;
            _logoutService = logoutService;
            _distributedCache = distributedCache;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand user)
        {
            return Ok(await _registerCommandHandler.Handle(user));
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserCommand request)
        {
            if (await _logoutService.IsActiveAsync(GetCurrentToken()))
            {
                return Ok(await _distributedCache.GetStringAsync("token"));
            }
            var (token, refreshToken) = await _loginUserCommandHandler.Handle(request);
            if (!string.IsNullOrEmpty(refreshToken))
            {
                SetRefreshTokenInCookie(refreshToken);
            }
            return Ok(token);
        }
        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var (token, refreshedToken) = await _refreshTokenQueryHandler.RefreshToken(refreshToken);

            SetRefreshTokenInCookie(refreshedToken);

            return Ok(token);
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var token = GetCurrentToken();
            if (token is null || !User.Identity.IsAuthenticated)
                return Ok(new { Message = "You wasn't logged in" });
            await _logoutService.Logout(token);
            return Ok();
        }
        private string GetCurrentToken()
        {
            var authHeader = HttpContext.Request?.Headers["authorization"];
            return authHeader.Equals(StringValues.Empty) ? string.Empty : authHeader.Single<string>().Split(" ").Last();
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
