using Application.Features.UserFeature.Command;
using Application.Features.UserFeature.Handler.RoleHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Features.UserFeature.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IRoleCommandHandler _roleCommandHandler;

        public AuthsController(IRoleCommandHandler roleCommandHandler)
        {
            _roleCommandHandler = roleCommandHandler;
        }
        [Authorize(Roles = "Administrators")]
        [HttpPost("role")]
        public async Task<IActionResult> AddRole(AddRoleCommand role)
        {
            return Ok(await _roleCommandHandler.Handel(role));
        }
    }
}
