using Application.Command.GenreCommand;
using Application.Handler.GenreHandler;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrators,Librarians")]
        public async Task<IActionResult> AddGenre(AddGenreCommand command)
        {
            return Ok(await _addGenreCommandHandler.Handel(command));
        }
    }
}
