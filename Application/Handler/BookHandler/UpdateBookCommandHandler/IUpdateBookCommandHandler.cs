using Application.Command.BookCommand;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.BookHandler.UpdateBookCommandHandler;

public interface IUpdateBookCommandHandler
{
    Task<Response<BookRequest>> Handel(UpdateBookCommand command);
}