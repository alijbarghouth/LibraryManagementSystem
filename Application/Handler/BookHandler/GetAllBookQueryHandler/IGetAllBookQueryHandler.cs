using Domain.DTOs.BookDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.BookHandler.GetAllBookQueryHandler;

public interface IGetAllBookQueryHandler
{
    Task<List<Response<Book>>> Handel();
}