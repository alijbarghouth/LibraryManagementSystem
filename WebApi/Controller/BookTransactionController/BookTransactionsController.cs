using Application.Command.BookTransactionCommand;
using Application.Handler.BookTransactionHandler.AcceptReturnedBook;
using Application.Handler.BookTransactionHandler.CheckOutBook;
using Application.Handler.BookTransactionHandler.GetOverdueBooks;
using Application.Handler.BookTransactionHandler.ReserveBook;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.BookTransactionController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class BookTransactionsController : ControllerBase
    {
        private readonly IReserveBookCommandHandler _reserveBookCommandHandler;
        private readonly ICheckOutBookCommandHandler _checkOutBookCommandHandler;
        private readonly IAcceptReturnedBookCommandHandler _acceptReturnedBookCommandHandler;
        private readonly IGetOverdueBooksQueryHandler _getOverdueBooksQueryHandler;

        public BookTransactionsController(IReserveBookCommandHandler reserveBookCommandHandler,
            ICheckOutBookCommandHandler checkOutBookCommandHandler,
            IAcceptReturnedBookCommandHandler acceptReturnedBookCommandHandler,
            IGetOverdueBooksQueryHandler getOverdueBooksQueryHandler)
        {
            _reserveBookCommandHandler = reserveBookCommandHandler;
            _checkOutBookCommandHandler = checkOutBookCommandHandler;
            _acceptReturnedBookCommandHandler = acceptReturnedBookCommandHandler;
            _getOverdueBooksQueryHandler = getOverdueBooksQueryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> ReserveBook(ReserveBookCommand command)
        {
            return Ok(await _reserveBookCommandHandler.Handel(command));
        }

        [HttpPatch("checkout")]
        public async Task<IActionResult> CheckOutBook(CheckOutBookCommand command)
        {
            return Ok(await _checkOutBookCommandHandler.Handel(command));
        }
        [HttpPatch("accept")]
        public async Task<IActionResult> AcceptReturnedBook(AcceptReturnedBookCommand command)
        {
            return Ok(await _acceptReturnedBookCommandHandler.Handel(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetOverdueBooks()
        {
            return Ok(await _getOverdueBooksQueryHandler.Handel());
        }
    }
}