using Domain.DTOs.BookAuthorDTOs;
using Domain.Repositories.BookAuthorRepository;
using Domain.Shared.Exceptions;

namespace Domain.Services.BookAuthorService;

public sealed class BookAuthorService : IBookAuthorService
{
    private readonly IBookAuthorRepository _bookAuthorRepository;
    private readonly IUnitOfWork _unitOfWork;
    public BookAuthorService(IBookAuthorRepository bookAuthorRepository, IUnitOfWork unitOfWork)
    {
        _bookAuthorRepository = bookAuthorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> AddBookAuthor(BookAuthor bookAuthor, CancellationToken cancellationToken = default)
    {
        var result = await _bookAuthorRepository.AddBookAuthor(bookAuthor);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
