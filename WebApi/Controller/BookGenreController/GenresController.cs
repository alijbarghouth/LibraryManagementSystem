using Application.Command.GenreCommand;
using Application.Handler.GenreHandler;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.BookGenreController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class GenresController : ControllerBase
    {
        private readonly IAddGenreCommandHandler _addGenreCommandHandler;

        public GenresController(IAddGenreCommandHandler addGenreCommandHandler)
        {
            _addGenreCommandHandler = addGenreCommandHandler;
        }
        [HttpPost]
        public async Task<IActionResult> AddBookGenre(AddGenreCommand command)
        {
            return Ok(await _addGenreCommandHandler.Handel(command));
        }
    }
}
