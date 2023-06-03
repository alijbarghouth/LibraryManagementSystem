using Domain.DTOs.BookDTOs;
using Domain.Repositories.BookRepository.BookCrudsRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.BookService.BookCruds;

public class BookCrudsService : IBookCrudsService
{
    private readonly IBookCrudsRepository _bookCrudsRepository;
    private readonly ISharedRepository _sharedRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookCrudsService(IBookCrudsRepository bookCrudsRepository
        , ISharedRepository sharedRepository, IUnitOfWork unitOfWork)
    {
        _bookCrudsRepository = bookCrudsRepository;
        _sharedRepository = sharedRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BookRequest> AddBook(BookRequest book, CancellationToken cancellationToken = default)
    {
        if (await _sharedRepository.IsBookExistsByTitle(book.Title))
            throw new NotFoundException("book is exists");
        if (!await _sharedRepository.IsBookGenreExistsById(book.GenreId))
            throw new NotFoundException("genre is not exists");
        await _bookCrudsRepository.AddBook(book);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return book;
    }

    public async Task<bool> DeleteBook(Guid bookId, CancellationToken cancellationToken = default)
    {
        if (!await _sharedRepository.IsBookExistsByBookId(bookId))
            throw new NotFoundException("book is not exists");
        var result = await _bookCrudsRepository.DeleteBook(bookId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<BookRequest> UpdateBook
        (Guid bookId, BookRequest book, CancellationToken cancellationToken = default)
    {
        if (!await _sharedRepository.IsBookExistsByBookId(bookId))
            throw new NotFoundException("book is not found");
        if (!await _sharedRepository.IsBookGenreExistsById(book.GenreId))
            throw new NotFoundException("genre is not found");
        var result = await _bookCrudsRepository.UpdateBook(bookId, book);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<List<Book>> GetAllBook()
    {
        return await _bookCrudsRepository.GetAllBook();
    }
}