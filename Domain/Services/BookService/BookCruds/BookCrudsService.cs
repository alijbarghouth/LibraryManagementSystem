using Domain.DTOs.BookDTOs;
using Domain.Repositories.BookRepository.BookCrudsRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.BookService.BookCruds;

public sealed class BookCrudsService : IBookCrudsService
{
    private readonly IBookCrudsRepository _bookCrudsRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedBookManagementRepository _bookManagementRepository;

    public BookCrudsService(IBookCrudsRepository bookCrudsRepository
        , IUnitOfWork unitOfWork
        , ISharedBookManagementRepository bookManagementRepository)
    {
        _bookCrudsRepository = bookCrudsRepository;
        _unitOfWork = unitOfWork;
        _bookManagementRepository = bookManagementRepository;
    }

    public async Task<BookRequest> AddBook(BookRequest book, CancellationToken cancellationToken = default)
    {
        if (await _bookManagementRepository.IsBookExistsByTitle(book.Title))
            throw new NotFoundException("book is exists");
        await _bookCrudsRepository.AddBook(book);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return book;
    }

    public async Task<bool> DeleteBook(Guid bookId, CancellationToken cancellationToken = default)
    {
        if (!await _bookManagementRepository.IsBookExistsByBookId(bookId))
            throw new NotFoundException("book is not exists");
        var result = await _bookCrudsRepository.DeleteBook(bookId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<BookRequest> UpdateBook
        (Guid bookId, BookRequest book, CancellationToken cancellationToken = default)
    {
        if (!await _bookManagementRepository.IsBookExistsByBookId(bookId))
            throw new NotFoundException("book is not found");

        var result = await _bookCrudsRepository.UpdateBook(bookId, book);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<List<Book>> GetAllBook()
    {
        return await _bookCrudsRepository.GetAllBook();
    }
}