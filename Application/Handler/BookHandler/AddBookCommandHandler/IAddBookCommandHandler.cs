using Application.Command.BookCommand;
using Domain.DTOs.BookDTOs;

namespace Application.Handler.BookHandler.AddBookCommandHandler;

public interface IAddBookCommandHandler
{
    Task<BookRequest> Handel(AddBookCommand command);
}