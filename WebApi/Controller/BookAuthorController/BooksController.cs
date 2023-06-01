using Application.Command.BookCommand;
using Application.Handler.BookHandler.AddBookCommandHandler;
using Application.Handler.BookHandler.SearchBookByAuthorName;
using Application.Handler.BookHandler.SearchBookByGenre;
using Application.Handler.BookHandler.SearchBookByTitle;
using Application.Query.BookQuery;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.BookAuthorController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class BooksController : ControllerBase
    {
        private readonly ISearchBookByTitleQueryHandler _searchByTitleQueryHandler;
        private readonly ISearchBookByAuthorNameQueryHandler _searchByAuthorNameQueryHandler;
        private readonly ISearchBookByGenreQueryHandler _searchByGenreQueryHandler;
        private readonly IAddBookCommandHandler _addBookCommandHandler;
        public BooksController(ISearchBookByTitleQueryHandler searchByTitleQueryHandler
            , ISearchBookByAuthorNameQueryHandler searchByAuthorNameQueryHandler
            , ISearchBookByGenreQueryHandler searchByGenreQueryHandler
            , IAddBookCommandHandler addBookCommandHandler)
        {
            _searchByTitleQueryHandler = searchByTitleQueryHandler;
            _searchByAuthorNameQueryHandler = searchByAuthorNameQueryHandler;
            _searchByGenreQueryHandler = searchByGenreQueryHandler;
            _addBookCommandHandler = addBookCommandHandler;
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookCommand command)
        {
            var book = await _addBookCommandHandler.Handel(command);
            return Ok(book);
        }
        [HttpGet("searchByTitle")]
        public async Task<IActionResult> GetBookByTitle([FromQuery] SearchBookByTitleQuery? query)
        {
            var book = await _searchByTitleQueryHandler.Handel(query);
            return Ok(book);
        }
        [HttpGet("searchByAuthorName")]
        public async Task<IActionResult> GetBookByAuthorName([FromQuery] SearchBookByAuthorNameQuery? query)
        {
            var book = await _searchByAuthorNameQueryHandler.Handel(query);
            return Ok(book);
        } 
        [HttpGet("searchByBookGenre")]
        public async Task<IActionResult> GetBookByBookGenre([FromQuery] SearchBookByGenerQuery query)
        {
            var book = await _searchByGenreQueryHandler.Handel(query);
            return Ok(book);
        }
    }
}
