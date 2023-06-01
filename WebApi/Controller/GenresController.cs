using Application.Command.GenreCommand;
using Application.Handler.GenreHandler;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class GenresController : ControllerBase
    {
        private readonly IAddBookGenreCommandHandler _addBookGenreCommandHandler;

        public GenresController(IAddBookGenreCommandHandler addBookGenreCommandHandler)
        {
            _addBookGenreCommandHandler = addBookGenreCommandHandler;
        }
        [HttpPost]
        public async Task<IActionResult> AddBookGenre(AddBookGenreCommand command)
        {
            return Ok(await _addBookGenreCommandHandler.Handel(command));
        }
    }
}
