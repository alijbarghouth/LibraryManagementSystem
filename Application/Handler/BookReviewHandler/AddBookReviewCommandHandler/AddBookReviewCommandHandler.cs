using Application.Cashing;
using Application.Command.BookReviewCommand;
using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;
using Domain.Services.BookReviewService;

namespace Application.Handler.BookReviewHandler.AddBookReviewCommandHandler;

public class AddBookReviewCommandHandler : IAddBookReviewCommandHandler
{
    private readonly IBookReviewService _bookReviewService;
    private readonly ICashService _cashService;
    public AddBookReviewCommandHandler(IBookReviewService bookReviewService,
        ICashService cashService)
    {
        _bookReviewService = bookReviewService;
        _cashService = cashService;
    }

    public async Task<Response<BookReview>> Handel(AddBookReviewCommand command)
    {
        const string key = "BookReview";
        var bookReview =  await _bookReviewService.AddBookReview(command.BookReview);
        await _cashService.RemoveAsync(key);
        return bookReview;
    }
}