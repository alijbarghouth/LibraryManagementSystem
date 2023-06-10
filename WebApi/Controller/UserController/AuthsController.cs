using Application.Command.UserCommand;
using Application.Handler.UserHandler.DeleteAccountHandler;
using Application.Handler.UserHandler.DeleteLibrarianHandler;
using Application.Handler.UserHandler.ResetPasswordHandler;
using Application.Handler.UserHandler.RoleHandler;
using Application.Handler.UserHandler.UpdateLibrarianHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class AuthsController : ControllerBase
    {
        private readonly IRoleCommandHandler _roleCommandHandler;
        private readonly IUpdateLibrarianRequestCommandHandler _updateLibrarianRequestCommandHandler;
        private readonly IDeleteLibrarianRequestCommandHandler _deleteLibrarianRequestCommandHandler;
        private readonly IResetPasswordCommandHandler _resetPasswordCommandHandler;
        private readonly IDeleteAccountCommandHandler _deleteAccountCommandHandler;

        public AuthsController(IRoleCommandHandler roleCommandHandler
            , IUpdateLibrarianRequestCommandHandler librarianRequestCommandHandler,
            IDeleteLibrarianRequestCommandHandler deleteLibrarianRequestCommandHandler,
            IResetPasswordCommandHandler resetPasswordCommandHandler,
            IDeleteAccountCommandHandler deleteAccountCommandHandler)
        {
            _roleCommandHandler = roleCommandHandler;
            _updateLibrarianRequestCommandHandler = librarianRequestCommandHandler;
            _deleteLibrarianRequestCommandHandler = deleteLibrarianRequestCommandHandler;
            _resetPasswordCommandHandler = resetPasswordCommandHandler;
            _deleteAccountCommandHandler = deleteAccountCommandHandler;
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost("role")]
        public async Task<IActionResult> AddRole(AddRoleCommand role)
        {
            return Ok(await _roleCommandHandler.Handel(role));
        }

        [Authorize(Roles = "Administrators")]
        [HttpPut]
        public async Task<IActionResult> UpdateLibrarian(UpdateLibrarianRequestCommand command)
        {
            return Ok(await _updateLibrarianRequestCommandHandler.Handel(command));
        }

        [Authorize(Roles = "Administrators,Librarians")]
        [HttpDelete]
        public async Task<IActionResult> DeleteLibrarian(DeleteLibrarianRequestCommand command)
        {
            return Ok(await _deleteLibrarianRequestCommandHandler.Handel(command));
        }

        [Authorize]
        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            return Ok(await _resetPasswordCommandHandler.Handel(command));
        }

        public async Task<IActionResult> DeleteAccount(DeleteAccountCommand command)
        {
            await _deleteAccountCommandHandler.Handel(command);
            return Ok("user Disabled");
        }
    }
}