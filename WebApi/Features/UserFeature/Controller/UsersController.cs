using Application.Features.UserFeature.Command;
using Application.Features.UserFeature.Handler.LoginHandler;
using Application.Features.UserFeature.Handler.RegisterHandler;
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
        private readonly IRegisterUserCommandHandler _registerCommandHandler;
        private readonly ILoginUserCommandHandler _loginUserCommandHandler;
        public UsersController(RegisterUserCommandHandler registerCommandHandler
            , ILoginUserCommandHandler loginUserCommandHandler)
        {
            _registerCommandHandler = registerCommandHandler;
            _loginUserCommandHandler = loginUserCommandHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand user)
        {
            return Ok(await _registerCommandHandler.Handle(user));
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserCommand request)
        {
            var (token, refreshToken) = await _loginUserCommandHandler.Handle(request);
            if (!string.IsNullOrEmpty(refreshToken))
            {
                SetRefreshTokenInCookie(refreshToken);
            }
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
