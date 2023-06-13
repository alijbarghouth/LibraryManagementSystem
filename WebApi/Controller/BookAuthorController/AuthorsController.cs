using Application.Command.AuthorCommand;
using Application.Handler.AuthorHandler.AddAuthorCommandHandler;
using Application.Handler.AuthorHandler.DeleteAuthorCommandHandler;
using Application.Handler.AuthorHandler.GetAuthorByBookIdQueryHandler;
using Application.Handler.AuthorHandler.UpdateAuthorCommandHandler;
using Application.Query.AuthorQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.BookAuthorController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class AuthorsController : ControllerBase
    {
        private readonly IAddAuthorCommandHandler _authorCommandHandler;
        private readonly IDeleteAuthorCommandHandler _deleteAuthorCommandHandler;
        private readonly IUpdateAuthorCommandHandler _updateAuthorCommandHandler;
        private readonly IGetAuthorByBookIdQueryHandler _getAuthorByBookIdQueryHandler;
        public AuthorsController(IAddAuthorCommandHandler authorCommandHandler
            , IDeleteAuthorCommandHandler deleteAuthorCommandHandler
            , IUpdateAuthorCommandHandler updateAuthorCommandHandler
            , IGetAuthorByBookIdQueryHandler getAuthorByBookIdQueryHandler)
        {
            _authorCommandHandler = authorCommandHandler;
            _deleteAuthorCommandHandler = deleteAuthorCommandHandler;
            _updateAuthorCommandHandler = updateAuthorCommandHandler;
            _getAuthorByBookIdQueryHandler = getAuthorByBookIdQueryHandler;
        }
        [Authorize(Roles = "Administrators,Librarians")]
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AddAuthorCommand command)
        {
            return Ok(await _authorCommandHandler.Handel(command));
        }
        [Authorize(Roles = "Administrators,Librarians")]
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            return Ok(await _updateAuthorCommandHandler.Handel(command));
        }
        [Authorize(Roles = "Administrators,Librarians")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor([FromQuery] DeleteAuthorCommand command)
        {
            return Ok(await _deleteAuthorCommandHandler.Handel(command));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAuthorByBookId([FromQuery] GetAuthorByBookIdQuery query)
        {
            return Ok(await _getAuthorByBookIdQueryHandler.Handel(query));
        }
    }
}