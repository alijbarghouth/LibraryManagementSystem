using Application.Query.BookReview;
using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.BookReviewHandler.GetAllBookReviewQueryHandler;

public interface IGetAllBookReviewCommandHandler
{
    Task<List<Response<BookReview>>> Handel(GetAllBookReviewQuery query);
}