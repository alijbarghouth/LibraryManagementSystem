using Application.Command.BookCommand;
using Application.Handler.BookHandler.AddBookCommandHandler;
using Application.Handler.BookHandler.DeleteBookCommandHandler;
using Application.Handler.BookHandler.GetAllBookQueryHandler;
using Application.Handler.BookHandler.UpdateBookCommandHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.BookAuthorController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class BooksController : ControllerBase
    {
        private readonly IUpdateBookCommandHandler _updateBookCommandHandler;
        private readonly IAddBookCommandHandler _addBookCommandHandler;
        private readonly IDeleteBookCommandHandler _deleteBookCommandHandler;
        private readonly IGetAllBookQueryHandler _getAllBookQueryHandler;

        public BooksController(IUpdateBookCommandHandler updateBookCommandHandler
            , IAddBookCommandHandler addBookCommandHandler
            , IDeleteBookCommandHandler deleteBookCommandHandler
            , IGetAllBookQueryHandler getAllBookQueryHandler)
        {
            _updateBookCommandHandler = updateBookCommandHandler;
            _addBookCommandHandler = addBookCommandHandler;
            _deleteBookCommandHandler = deleteBookCommandHandler;
            _getAllBookQueryHandler = getAllBookQueryHandler;
        }

        [HttpPost]
        [Authorize(Roles = "Administrators,Librarians")]
        public async Task<IActionResult> AddBook(AddBookCommand command)
        {
            return Ok(await _addBookCommandHandler.Handel(command));
        }

        [HttpPut]
        [Authorize(Roles = "Administrators,Librarians")]
        public async Task<IActionResult> UpdateBook(UpdateBookCommand command)
        {
            return Ok(await _updateBookCommandHandler.Handel(command));
        }

        [HttpDelete]
        [Authorize(Roles = "Administrators,Librarians")]
        public async Task<IActionResult> DeleteBook(DeleteBookCommand command)
        {
            return Ok(await _deleteBookCommandHandler.Handel(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            return Ok(await _getAllBookQueryHandler.Handel());
        }
    }
}