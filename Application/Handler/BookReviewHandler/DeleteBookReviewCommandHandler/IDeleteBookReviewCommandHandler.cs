using Application.Command.BookReviewCommand;

namespace Application.Handler.BookReviewHandler.DeleteBookReviewCommandHandler;

public interface IDeleteBookReviewCommandHandler
{
    Task<bool> Handel(DeleteBookReviewCommand command);
}