using Application.Command.UserCommand;
using Application.Handler.UserHandler.ConfirmedEmailHandler;
using Application.Handler.UserHandler.LoginHandler;
using Application.Handler.UserHandler.RefreshTokenHandler;
using Application.Handler.UserHandler.RegisterHandler;
using Domain.DTOs.NotificationDTOs;
using Domain.Services.NotificationService;
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
        private readonly INotificationService _notificationService;
        private readonly IConfirmedEmailCommandHandler _confirmedEmailCommandHandler;

        public UsersController(IRegisterUserCommandHandler registerCommandHandler,
            ILoginUserCommandHandler loginUserCommandHandler,
            IRefreshTokenQueryHandler refreshTokenQueryHandler,
            INotificationService notificationService,
            IConfirmedEmailCommandHandler confirmedEmailCommandHandler)
        {
            _registerCommandHandler = registerCommandHandler;
            _loginUserCommandHandler = loginUserCommandHandler;
            _refreshTokenQueryHandler = refreshTokenQueryHandler;
            _notificationService = notificationService;
            _confirmedEmailCommandHandler = confirmedEmailCommandHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            var user = await _registerCommandHandler.Handle(command);
            const string emailBody = $"please confirm your email address <a href=\"#URL#\">Click here</a>";

            var callBackUrl = Request.Scheme + "://" + Request.Host +
                              Url.Action("ConfirmEmail", "Users",
                                  new { UserId = user.Id });
            const string subject = "EmailConfirmation";

            await SendEmail(user.Id, subject, emailBody, callBackUrl);

            return Ok("Mail has successfully been sent please Confirm Email");
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

        [Route("ConfirmEmail")]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(Guid userId)
        {
            if (string.IsNullOrEmpty(userId.ToString()))
                return BadRequest();
            await _confirmedEmailCommandHandler.Handel(userId);
            return Ok("thank you for confirmed");
        }

        private async Task SendEmail
            (Guid userId, string subject, string emailBody, string callBackUrl)
        {
            var body = emailBody.Replace("#URL#", callBackUrl);

            await _notificationService.SendEmail
                (userId, body, subject, new CancellationToken());
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