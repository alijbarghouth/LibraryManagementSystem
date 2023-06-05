using Application.Command.UserCommand;
using Application.Handler.UserHandler.DeleteLibrarianHandler;
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

        public AuthsController(IRoleCommandHandler roleCommandHandler
            , IUpdateLibrarianRequestCommandHandler librarianRequestCommandHandler,
            IDeleteLibrarianRequestCommandHandler deleteLibrarianRequestCommandHandler)
        {
            _roleCommandHandler = roleCommandHandler;
            _updateLibrarianRequestCommandHandler = librarianRequestCommandHandler;
            _deleteLibrarianRequestCommandHandler = deleteLibrarianRequestCommandHandler;
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
    }
}