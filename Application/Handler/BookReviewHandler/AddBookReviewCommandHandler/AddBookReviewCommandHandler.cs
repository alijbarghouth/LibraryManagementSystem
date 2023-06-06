using Application.Command.BookReviewCommand;
using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;
using Domain.Services.BookReviewService;

namespace Application.Handler.BookReviewHandler.AddBookReviewCommandHandler;

public class AddBookReviewCommandHandler : IAddBookReviewCommandHandler
{
    private readonly IBookReviewService _bookReviewService;

    public AddBookReviewCommandHandler(IBookReviewService bookReviewService)
    {
        _bookReviewService = bookReviewService;
    }

    public async Task<Response<BookReview>> Handel(AddBookReviewCommand command)
    {
        return await _bookReviewService.AddBookReview(command.BookReview);
    }
}