using Application.Handler.BookHandler.SearchByTitle;
using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller.BookControler
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ISearchByTitleQueryHandler _searchByTitleQueryHandler;

        public BooksController(ISearchByTitleQueryHandler searchByTitleQueryHandler)
        {
            _searchByTitleQueryHandler = searchByTitleQueryHandler;
        }
        [HttpGet]
        public async Task<ActionResult<PagedResponse<Book>>> GetBookByTitle([FromQuery] SearchByTitleQuery? query)
        {
            var book = await _searchByTitleQueryHandler.Handel(query);
            if(book.data.Count == 0)
            {
                return NoContent();
            }
            return Ok(book);
        }
    }
}
