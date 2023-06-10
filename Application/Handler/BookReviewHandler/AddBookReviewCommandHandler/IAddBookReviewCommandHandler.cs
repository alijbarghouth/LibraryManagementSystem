using Application.Command.BookReviewCommand;
using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.BookReviewHandler.AddBookReviewCommandHandler;

public interface IAddBookReviewCommandHandler
{
    Task<Response<BookReview>> Handel(AddBookReviewCommand command);
}