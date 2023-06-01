using Application.Command.BookAuthorCommand;
using Domain.DTOs.BookAuthorDTOs;

namespace Application.Handler.BookAuthorHandler;

public interface IBookAuthorCommandHandler
{
    Task<BookAuthor> Handel(BookAuthorCommand command);
}
