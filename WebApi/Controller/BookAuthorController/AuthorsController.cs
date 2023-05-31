using Application.Command.AuthorCommand;
using Application.Handler.AuthorHandler;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller.BookAuthorController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAddAuthorCommandHandler _authorCommandHandler;

        public AuthorsController(IAddAuthorCommandHandler authorCommandHandler)
        {
            _authorCommandHandler = authorCommandHandler;
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AddAuthorCommand command)
        {
            return Ok(await _authorCommandHandler.Handel(command));
        }
    }
}
