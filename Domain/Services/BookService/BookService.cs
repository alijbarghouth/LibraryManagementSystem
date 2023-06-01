using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;
using Domain.Repositories.BookRepository;
using Domain.Repositories.GenreRepository;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.BookService;

public sealed class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IUnitOfWork _unitOfWork;
    private static readonly string BaseUrl = "/api/Books";

    public BookService(IBookRepository bookRepository
        , IUnitOfWork unitOfWork, IGenreRepository genreRepository)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _genreRepository = genreRepository;
    }

    public async Task<PagedResponse<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter)
    {
        var query = await _bookRepository.SearchBookByTitle(bookTitle, filter);
        if (query.Count == 0)
            throw new NoContentException("no content");

        return GetPagedResponse(query, filter, bookTitle, "searchByTitle");
    }

    public async Task<PagedResponse<Book>> SearchBookByAuthor(string authorName, PaginationFilter filter)
    {
        var query = await _bookRepository.SearchBookByAuhtorName(authorName, filter);
        if (query.Count == 0)
            throw new NoContentException("no content");

        return GetPagedResponse(query, filter, authorName, "searchByAuthorName");
    }

    public async Task<PagedResponse<Book>> SearchBookByBookGenre(string bookGenre, PaginationFilter filter)
    {
        var query = await _bookRepository.SearchBookByBookGenre(bookGenre, filter);
        if (query.Count == 0)
            throw new NoContentException("no content");

        return GetPagedResponse(query, filter, bookGenre, "searchByAuthorName");
    }

    public async Task<BookRequest> AddBook(BookRequest book, CancellationToken cancellationToken = default)
    {
        if (await _bookRepository.IsBookExists(book.Title))
            throw new BadRequestException("book is exists");
        if (await _genreRepository.IsBookGenreExistsById(book.GenreId))
            throw new BadRequestException("genre is exists");
        await _bookRepository.AddBook(book);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return book;
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