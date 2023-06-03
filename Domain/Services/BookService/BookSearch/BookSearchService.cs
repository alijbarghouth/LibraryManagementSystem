using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;
using Domain.Repositories.BookRepository.SearchBookRepository;
using Domain.Repositories.GenreRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.BookService.BookSearch;

public sealed class BookSearchService : IBookSearchService
{
    private readonly ISearchBookRepository _searchBookRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly ISharedRepository _sharedRepository;
    private readonly IUnitOfWork _unitOfWork;
    private static readonly string BaseUrl = "/api/Books";

    public BookSearchService(ISearchBookRepository searchBookRepository
        , IUnitOfWork unitOfWork, IGenreRepository genreRepository
        , ISharedRepository sharedRepository)
    {
        _searchBookRepository = searchBookRepository;
        _unitOfWork = unitOfWork;
        _genreRepository = genreRepository;
        _sharedRepository = sharedRepository;
    }

    public async Task<PagedResponse<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter)
    {
        var query = await _searchBookRepository.SearchBookByTitle(bookTitle, filter);
        if (query.Count == 0)
            throw new NoContentException("no content");

        return GetPagedResponse(query, filter, bookTitle, "searchByTitle");
    }

    public async Task<PagedResponse<Book>> SearchBookByAuthor(string authorName, PaginationFilter filter)
    {
        var query = await _searchBookRepository.SearchBookByAuhtorName(authorName, filter);
        if (query.Count == 0)
            throw new NoContentException("no content");

        return GetPagedResponse(query, filter, authorName, "searchByAuthorName");
    }

    public async Task<PagedResponse<Book>> SearchBookByBookGenre(string bookGenre, PaginationFilter filter)
    {
        var query = await _searchBookRepository.SearchBookByBookGenre(bookGenre, filter);
        if (query.Count == 0)
            throw new NoContentException("no content");

        return GetPagedResponse(query, filter, bookGenre, "searchByAuthorName");
    }
    private static PagedResponse<Book> GetPagedResponse(List<Book> query
        , PaginationFilter filter, string searchTitle, string endPointName)
    {
        var paginationResponse = new PagedResponse<Book>(query)
        {
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber
        };
        paginationResponse.NextPage = $"{BaseUrl}/{endPointName}" +
                                      $"?AuthorName={searchTitle}" +
                                      $"&Queries.PageNumber={paginationResponse.PageNumber + 1}&Queries.PageSize={paginationResponse.PageSize}";
        paginationResponse.PreviousPage = paginationResponse.PageNumber > 1
            ? $"{BaseUrl}/{endPointName}" +
              $"?AuthorName={searchTitle}" +
              $"&Queries.PageNumber={paginationResponse.PageNumber - 1}&Queries.PageSize={paginationResponse.PageSize}"
            : null;

        return paginationResponse;
    }
}