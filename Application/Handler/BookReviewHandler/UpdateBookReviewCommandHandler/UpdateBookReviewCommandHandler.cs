using Application.Command.BookReviewCommand;
using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;
using Domain.Services.BookReviewService;

namespace Application.Handler.BookReviewHandler.UpdateBookReviewCommandHandler;

public class UpdateBookReviewCommandHandler : IUpdateBookReviewCommandHandler
{
    private readonly IBookReviewService _bookReviewService;

    public UpdateBookReviewCommandHandler(IBookReviewService bookReviewService)
    {
        _bookReviewService = bookReviewService;
    }

    public async Task<Response<BookReview>> Handel(UpdateBookReviewCommand command)
    {
        return await _bookReviewService.UpdateBookReview(command.BookReviewId, command.BookReview);
    }
}