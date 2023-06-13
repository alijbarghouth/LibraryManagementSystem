using Application.Cashing;
using Application.Query.AuthorQuery;
using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.Response;
using Domain.Services.AuthorService;

namespace Application.Handler.AuthorHandler.GetAuthorByBookIdQueryHandler;

public sealed class GetAuthorByBookIdQueryHandler : IGetAuthorByBookIdQueryHandler
{
    private readonly IAuthorCrudsService _authorCrudsService;
    private readonly ICashService _cashService;
    public GetAuthorByBookIdQueryHandler(IAuthorCrudsService authorCrudsService,
        ICashService cashService)
    {
        _authorCrudsService = authorCrudsService;
        _cashService = cashService;
    }

    public async Task<List<Response<Author>>> Handel(GetAuthorByBookIdQuery query)
    {
        var key = $"{query.BookId} Authors";
        return await _cashService.GetAsync(key, async () =>
        {
            var author = await _authorCrudsService.GetAuthorByBookId(query.BookId);
            return author;
        });
    }
}
