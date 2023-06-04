using Application.Command.BookGenreCommand;
using Application.Handler.BookGenreHandler.AddBookGenreCommandHandler;
using Domain.DTOs.BookGenreDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller.BookGenreController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookGenresController : ControllerBase
    {
        private readonly IAddBookGenreCommandHandler _addBookGenreCommandHandler;

        public BookGenresController(IAddBookGenreCommandHandler addBookGenreCommandHandler)
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
