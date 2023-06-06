using Application.Command.BookReviewCommand;
using Application.Handler.BookReviewHandler.AddBookReviewCommandHandler;
using Application.Handler.BookReviewHandler.DeleteBookReviewCommandHandler;
using Application.Handler.BookReviewHandler.GetAllBookReviewQueryHandler;
using Application.Handler.BookReviewHandler.UpdateBookReviewCommandHandler;
using Application.Query.BookReview;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.BookReviewController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class BookReviewsController : ControllerBase
    {
        private readonly IAddBookReviewCommandHandler _addBookReviewCommandHandler;
        private readonly IDeleteBookReviewCommandHandler _deleteBookReviewCommandHandler;
        private readonly IUpdateBookReviewCommandHandler _updateBookReviewCommandHandler;
        private readonly IGetAllBookReviewCommandHandler _getAllBookReviewCommandHandler;

        public BookReviewsController(IAddBookReviewCommandHandler addBookReviewCommandHandler,
            IDeleteBookReviewCommandHandler deleteBookReviewCommandHandler,
            IUpdateBookReviewCommandHandler updateBookReviewCommandHandler,
            IGetAllBookReviewCommandHandler getAllBookReviewCommandHandler)
        {
            _addBookReviewCommandHandler = addBookReviewCommandHandler;
            _deleteBookReviewCommandHandler = deleteBookReviewCommandHandler;
            _updateBookReviewCommandHandler = updateBookReviewCommandHandler;
            _getAllBookReviewCommandHandler = getAllBookReviewCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> AddBookReview(AddBookReviewCommand command)
        {
            return Ok(await _addBookReviewCommandHandler.Handel(command));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBookReview(UpdateBookReviewCommand command)
        {
            return Ok(await _updateBookReviewCommandHandler.Handel(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBookReview(DeleteBookReviewCommand command)
        {
            return Ok(await _deleteBookReviewCommandHandler.Handel(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBookReviewByUserIdAndBookId(GetAllBookReviewQuery query)
        {
            return Ok(await _getAllBookReviewCommandHandler.Handel(query));
        }
    }
}
