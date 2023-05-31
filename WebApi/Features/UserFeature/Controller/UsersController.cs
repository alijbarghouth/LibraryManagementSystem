﻿using Application.Features.UserFeature.Command;
using Application.Features.UserFeature.Handler.LoginHandler;
using Application.Features.UserFeature.Handler.RefreshTokenHandler;
using Application.Features.UserFeature.Handler.RegisterHandler;
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
