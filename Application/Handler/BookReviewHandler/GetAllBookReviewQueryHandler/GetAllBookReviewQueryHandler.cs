using Application.Query.BookReview;
using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;
using Domain.Services.BookReviewService;

namespace Application.Handler.BookReviewHandler.GetAllBookReviewQueryHandler;

public class GetAllBookReviewQueryHandler : IGetAllBookReviewCommandHandler
{
    private readonly IBookReviewService _bookReviewService;

    public GetAllBookReviewQueryHandler(IBookReviewService bookReviewService)
    {
        _bookReviewService = bookReviewService;
    }

    public async Task<List<Response<BookReview>>> Handel(GetAllBookReviewQuery query)
    {
        return await _bookReviewService.GetAllBookReviewByBookIdAndUserId(query.UserId, query.BookId);
    }
}