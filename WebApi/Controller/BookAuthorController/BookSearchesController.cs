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
    public class BookSearchesController : ControllerBase
    {
        private readonly ISearchBookByTitleQueryHandler _searchByTitleQueryHandler;
        private readonly ISearchBookByAuthorNameQueryHandler _searchByAuthorNameQueryHandler;
        private readonly ISearchBookByGenreQueryHandler _searchByGenreQueryHandler;
        public BookSearchesController(ISearchBookByTitleQueryHandler searchByTitleQueryHandler
            , ISearchBookByAuthorNameQueryHandler searchByAuthorNameQueryHandler
            , ISearchBookByGenreQueryHandler searchByGenreQueryHandler)
        {
            _searchByTitleQueryHandler = searchByTitleQueryHandler;
            _searchByAuthorNameQueryHandler = searchByAuthorNameQueryHandler;
            _searchByGenreQueryHandler = searchByGenreQueryHandler;
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
