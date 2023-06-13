using Application.Query.AuthorQuery;
using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.AuthorHandler.GetAuthorByBookIdQueryHandler;

public interface IGetAuthorByBookIdQueryHandler
{
    Task<List<Response<Author>>> Handel(GetAuthorByBookIdQuery query);
}
