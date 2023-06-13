using Application.Command.BookReviewCommand;
using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.BookReviewHandler.UpdateBookReviewCommandHandler;

public interface IUpdateBookReviewCommandHandler
{
    Task<Response<BookReview>> Handel(UpdateBookReviewCommand command);
}