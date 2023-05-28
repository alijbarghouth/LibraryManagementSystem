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
            return Ok(await _commandService.LoginUser(request));
        }
    }
}
