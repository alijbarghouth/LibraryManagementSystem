using Application.Handler.BookHandler.SearchByAuthorName;
using Application.Handler.BookHandler.SearchByTitle;
using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.BookAuthorController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class BooksController : ControllerBase
    {
        private readonly ISearchByTitleQueryHandler _searchByTitleQueryHandler;
        private readonly ISearchByAuthorNameQueryHandler _searchByAuthorNameQueryHandler;
        public BooksController(ISearchByTitleQueryHandler searchByTitleQueryHandler, ISearchByAuthorNameQueryHandler searchByAuthorNameQueryHandler)
        {
            _searchByTitleQueryHandler = searchByTitleQueryHandler;
            _searchByAuthorNameQueryHandler = searchByAuthorNameQueryHandler;
        }
        [HttpGet("searchByTitle")]
        public async Task<ActionResult<PagedResponse<Book>>> GetBookByTitle([FromQuery] SearchByTitleQuery? query)
        {
            var book = await _searchByTitleQueryHandler.Handel(query);
            if (book.data.Count == 0)
            {
                return NoContent();
            }
            return Ok(book);
        }
        [HttpGet("searchByAuthorName")]
        public async Task<ActionResult<PagedResponse<Book>>> GetBookByAuthorName([FromQuery] SearchByTAuthorNameQuery? query)
        {
            var book = await _searchByAuthorNameQueryHandler.Handel(query);
            if (book.data.Count == 0)
            {
                return NoContent();
            }
            return Ok(book);
        }
    }
}
