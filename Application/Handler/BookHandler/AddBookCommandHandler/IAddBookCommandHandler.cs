using Application.Command.BookCommand;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.BookHandler.AddBookCommandHandler;

public interface IAddBookCommandHandler
{
    Task<Response<BookRequest>> Handel(AddBookCommand command);
}