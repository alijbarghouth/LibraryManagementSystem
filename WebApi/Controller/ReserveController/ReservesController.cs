using Application.Command.ReserveBookCommand;
using Application.Handler.ReserveBookHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller.ReserveController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservesController : ControllerBase
    {
        private readonly IReserveBookCommandHandler _reserveBookCommandHandler;

        public ReservesController(IReserveBookCommandHandler reserveBookCommandHandler)
        {
            _reserveBookCommandHandler = reserveBookCommandHandler;
        }
        [HttpPost]
        public async Task<IActionResult> ReserveBook(ReserveBookCommand command)
        {
            return Ok(await _reserveBookCommandHandler.ReserveBook(command));
        }
    }
}
