using Application.Cashing;
using Application.Command.BookReviewCommand;
using Domain.Services.BookReviewService;

namespace Application.Handler.BookReviewHandler.DeleteBookReviewCommandHandler;

public class DeleteBookReviewCommandHandler : IDeleteBookReviewCommandHandler
{
    private readonly IBookReviewService _bookReviewService;
    private readonly ICashService _cashService;

    public DeleteBookReviewCommandHandler(IBookReviewService bookReviewService,
        ICashService cashService)
    {
        _bookReviewService = bookReviewService;
        _cashService = cashService;
    }

    public async Task<bool> Handel(DeleteBookReviewCommand command)
    {
        const string key = "BookReview";
        var result = await _bookReviewService.DeleteBookReview(command.BookReviewId);
        await _cashService.RemoveAsync(key);
        return result;
    }
}