using Application.Command.BookAuthorCommand;
using Application.Handler.BookAuthorHandler;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.BookAuthorController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class BookAuthorsController : ControllerBase
    {
        private readonly IBookAuthorCommandHandler _bookAuthorCommandHandler;

        public BookAuthorsController(IBookAuthorCommandHandler bookAuthorCommandHandler)
        {
            _bookAuthorCommandHandler = bookAuthorCommandHandler;
        }
        [HttpPost]
        public async Task<IActionResult> AddBookAuthor(BookAuthorCommand command)
        {
            return Ok(await _bookAuthorCommandHandler.Handel(command));
        }
    }
}
