using Application.Command.BookTransactionCommand;
using Application.Handler.BookTransactionHandler.AcceptReturnedBook;
using Application.Handler.BookTransactionHandler.CheckOutBook;
using Application.Handler.BookTransactionHandler.GetOverdueBooks;
using Application.Handler.BookTransactionHandler.RejectReserveBook;
using Application.Handler.BookTransactionHandler.ReserveBook;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IRejectReserveBookCommandHandler _rejectReserveBookCommandHandler;

        public BookTransactionsController(IReserveBookCommandHandler reserveBookCommandHandler,
            ICheckOutBookCommandHandler checkOutBookCommandHandler,
            IAcceptReturnedBookCommandHandler acceptReturnedBookCommandHandler,
            IGetOverdueBooksQueryHandler getOverdueBooksQueryHandler,
            IRejectReserveBookCommandHandler rejectReserveBookCommandHandler)
        {
            _reserveBookCommandHandler = reserveBookCommandHandler;
            _checkOutBookCommandHandler = checkOutBookCommandHandler;
            _acceptReturnedBookCommandHandler = acceptReturnedBookCommandHandler;
            _getOverdueBooksQueryHandler = getOverdueBooksQueryHandler;
            _rejectReserveBookCommandHandler = rejectReserveBookCommandHandler;
        }

        [HttpPost("reserve")]
        [Authorize]
        public async Task<IActionResult> ReserveBook(ReserveBookCommand command)
        {
            return Ok(await _reserveBookCommandHandler.Handel(command));
        }

        [Authorize(Roles = "Administrators,Librarians")]
        [HttpPatch("checkout")]
        public async Task<IActionResult> CheckOutBook(CheckOutBookCommand command)
        {
            return Ok(await _checkOutBookCommandHandler.Handel(command));
        }

        [HttpPatch("accept")]
        [Authorize(Roles = "Administrators,Librarians")]
        public async Task<IActionResult> AcceptReturnedBook(AcceptReturnedBookCommand command)
        {
            return Ok(await _acceptReturnedBookCommandHandler.Handel(command));
        }

        [HttpGet]
        [Authorize(Roles = "Administrators,Librarians")]
        public async Task<IActionResult> GetOverdueBooks()
        {
            return Ok(await _getOverdueBooksQueryHandler.Handel());
        }
        
        [HttpPatch("reject")]
        [Authorize(Roles = "Administrators,Librarians")]
        public async Task<IActionResult> RejectReserveBook(RejectReserveBookCommand command)
        {
            return Ok(await _rejectReserveBookCommandHandler.Handel(command));
        }
    }
}