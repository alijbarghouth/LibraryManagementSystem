using Application.Command.BookCommand;
using Domain.DTOs.BookDTOs;

namespace Application.Handler.BookHandler.UpdateBookCommandHandler;

public interface IUpdateBookCommandHandler
{
    Task<BookRequest> Handel(UpdateBookCommand command);
}