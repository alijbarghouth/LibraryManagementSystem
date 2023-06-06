using Application.Command.BookReviewCommand;
using Domain.Services.BookReviewService;

namespace Application.Handler.BookReviewHandler.DeleteBookReviewCommandHandler;

public class DeleteBookReviewCommandHandler : IDeleteBookReviewCommandHandler
{
    private readonly IBookReviewService _bookReviewService;

    public DeleteBookReviewCommandHandler(IBookReviewService bookReviewService)
    {
        _bookReviewService = bookReviewService;
    }

    public async Task<bool> Handel(DeleteBookReviewCommand command)
    {
        return await _bookReviewService.DeleteBookReview(command.BookReviewId);
    }
}