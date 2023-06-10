using Application.Cashing;
using Application.Command.BookReviewCommand;
using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;
using Domain.Services.BookReviewService;

namespace Application.Handler.BookReviewHandler.UpdateBookReviewCommandHandler;

public class UpdateBookReviewCommandHandler : IUpdateBookReviewCommandHandler
{
    private readonly IBookReviewService _bookReviewService;
    private readonly ICashService _cashService;
    public UpdateBookReviewCommandHandler(IBookReviewService bookReviewService,
        ICashService cashService)
    {
        _bookReviewService = bookReviewService;
        _cashService = cashService;
    }

    public async Task<Response<BookReview>> Handel(UpdateBookReviewCommand command)
    {
        const string key = "BookReview";
        var bookReview = await _bookReviewService.UpdateBookReview(command.BookReviewId, command.BookReview);
        await _cashService.RemoveAsync(key);
        return bookReview;
    }
}