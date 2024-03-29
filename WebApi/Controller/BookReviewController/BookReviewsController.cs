using Application.Command.BookReviewCommand;
using Application.Handler.BookReviewHandler.AddBookReviewCommandHandler;
using Application.Handler.BookReviewHandler.AverageRatingForEachBookHandler;
using Application.Handler.BookReviewHandler.DeleteBookReviewCommandHandler;
using Application.Handler.BookReviewHandler.GetAllBookReviewQueryHandler;
using Application.Handler.BookReviewHandler.UpdateBookReviewCommandHandler;
using Application.Query.BookReview;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAverageRatingForEachBookQueryHandler _averageRatingForEachBookQueryHandler;
        public BookReviewsController(IAddBookReviewCommandHandler addBookReviewCommandHandler,
            IDeleteBookReviewCommandHandler deleteBookReviewCommandHandler,
            IUpdateBookReviewCommandHandler updateBookReviewCommandHandler,
            IGetAllBookReviewCommandHandler getAllBookReviewCommandHandler,
            IAverageRatingForEachBookQueryHandler averageRatingForEachBookQueryHandler)
        {
            _addBookReviewCommandHandler = addBookReviewCommandHandler;
            _deleteBookReviewCommandHandler = deleteBookReviewCommandHandler;
            _updateBookReviewCommandHandler = updateBookReviewCommandHandler;
            _getAllBookReviewCommandHandler = getAllBookReviewCommandHandler;
            _averageRatingForEachBookQueryHandler = averageRatingForEachBookQueryHandler;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddBookReview(AddBookReviewCommand command)
        {
            return Ok(await _addBookReviewCommandHandler.Handel(command));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateBookReview(UpdateBookReviewCommand command)
        {
            return Ok(await _updateBookReviewCommandHandler.Handel(command));
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteBookReview(DeleteBookReviewCommand command)
        {
            return Ok(await _deleteBookReviewCommandHandler.Handel(command));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllBookReviewByBookId([FromQuery]GetAllBookReviewQuery query)
        {
            return Ok(await _getAllBookReviewCommandHandler.Handel(query));
        }
        [Authorize]
        [HttpGet("rating")]
        public async Task<IActionResult> AverageRatingForEachBook()
        {
            return Ok(await _averageRatingForEachBookQueryHandler.Handel());
        }
    }
}
