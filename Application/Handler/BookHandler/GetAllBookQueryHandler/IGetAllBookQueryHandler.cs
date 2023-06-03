using Domain.DTOs.BookDTOs;

namespace Application.Handler.BookHandler.GetAllBookQueryHandler;

public interface IGetAllBookQueryHandler
{
    Task<List<Book>> Handel();
}