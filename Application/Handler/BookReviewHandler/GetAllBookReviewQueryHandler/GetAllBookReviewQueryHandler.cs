using Application.Cashing;
using Application.Query.BookReview;
using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;
using Domain.Services.BookReviewService;

namespace Application.Handler.BookReviewHandler.GetAllBookReviewQueryHandler;

public class GetAllBookReviewQueryHandler : IGetAllBookReviewCommandHandler
{
    private readonly IBookReviewService _bookReviewService;
    private readonly ICashService _cashService;

    public GetAllBookReviewQueryHandler(IBookReviewService bookReviewService,
        ICashService cashService)
    {
        _bookReviewService = bookReviewService;
        _cashService = cashService;
    }

    public async Task<List<Response<BookReview>>> Handel(GetAllBookReviewQuery query)
    {
        var key = $"{query.UserId}{query.BookId}";
        return await _cashService.GetAsync<List<Response<BookReview>>>(key, async () =>
        {
            var bookReview = await _bookReviewService.GetAllBookReviewByBookIdAndUserId(query.UserId, query.BookId);
            return bookReview;
        });
    }
}