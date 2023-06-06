using Application.Command.UserCommand;
using Application.Handler.UserHandler.LoginHandler;
using Application.Handler.UserHandler.RefreshTokenHandler;
using Application.Handler.UserHandler.RegisterHandler;
using Microsoft.AspNetCore.Mvc;
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

        public UsersController(IRegisterUserCommandHandler registerCommandHandler,
            ILoginUserCommandHandler loginUserCommandHandler,
            IRefreshTokenQueryHandler refreshTokenQueryHandler)
        {
            _registerCommandHandler = registerCommandHandler;
            _loginUserCommandHandler = loginUserCommandHandler;
            _refreshTokenQueryHandler = refreshTokenQueryHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand user)
        {
            return Ok(await _registerCommandHandler.Handle(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserCommand request)
        {
            var loginUserResponse = await _loginUserCommandHandler.Handle(request);
            if (!string.IsNullOrEmpty(loginUserResponse.RefreshToken))
            {
                SetRefreshTokenInCookie(loginUserResponse.RefreshToken);
            }

            return Ok(loginUserResponse.Token);
        }

        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var (token, refreshedToken) = await _refreshTokenQueryHandler.RefreshToken(refreshToken);

            SetRefreshTokenInCookie(refreshedToken);

            return Ok(token);
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