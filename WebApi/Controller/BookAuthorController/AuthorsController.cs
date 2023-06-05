using Application.Command.AuthorCommand;
using Application.Handler.AuthorHandler.AddAuthorCommandHandler;
using Application.Handler.AuthorHandler.DeleteAuthorCommandHandler;
using Application.Handler.AuthorHandler.UpdateAuthorCommandHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.BookAuthorController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    [Authorize(Roles = "Administrators,Librarians")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAddAuthorCommandHandler _authorCommandHandler;
        private readonly IDeleteAuthorCommandHandler _deleteAuthorCommandHandler;
        private readonly IUpdateAuthorCommandHandler _updateAuthorCommandHandler;

        public AuthorsController(IAddAuthorCommandHandler authorCommandHandler
            , IDeleteAuthorCommandHandler deleteAuthorCommandHandler
            , IUpdateAuthorCommandHandler updateAuthorCommandHandler)
        {
            _authorCommandHandler = authorCommandHandler;
            _deleteAuthorCommandHandler = deleteAuthorCommandHandler;
            _updateAuthorCommandHandler = updateAuthorCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AddAuthorCommand command)
        {
            return Ok(await _authorCommandHandler.Handel(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            return Ok(await _updateAuthorCommandHandler.Handel(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(DeleteAuthorCommand command)
        {
            return Ok(await _deleteAuthorCommandHandler.Handel(command));
        }
    }
}