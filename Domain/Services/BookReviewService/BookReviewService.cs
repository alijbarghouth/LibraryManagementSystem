using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;
using Domain.Repositories.BookReviewRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.BookReviewService;

public class BookReviewService : IBookReviewService
{
    private readonly IBookReviewRepository _bookReviewRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedUserRepository _sharedUserRepository;
    private readonly ISharedBookManagementRepository _sharedBookManagementRepository;
    public BookReviewService(IBookReviewRepository bookReviewRepository,
        IUnitOfWork unitOfWork,
        ISharedUserRepository sharedUserRepository,
        ISharedBookManagementRepository sharedBookManagementRepository)
    {
        _bookReviewRepository = bookReviewRepository;
        _unitOfWork = unitOfWork;
        _sharedUserRepository = sharedUserRepository;
        _sharedBookManagementRepository = sharedBookManagementRepository;
    }

    public async Task<Response<BookReview>> AddBookReview(BookReview bookReview,
        CancellationToken cancellationToken = default)
    {
        if (!await _sharedBookManagementRepository.IsBookExistsByBookId(bookReview.BookId))
            throw new NotFoundException("book not found");
        if (!await _sharedUserRepository.IsUserExistsUserId(bookReview.UserId))
            throw new NotFoundException("user not found");
        var review = await _bookReviewRepository.AddBookReview(bookReview);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return review;
    }

    public async Task<Response<BookReview>> UpdateBookReview(Guid bookReviewId, UpdateBookReviewequest bookReview, CancellationToken cancellationToken = default)
    {
        if (!await _sharedBookManagementRepository.IsBookReviewExistsByBookReviewId(bookReviewId))
            throw new NotFoundException("book review not found");
        var review = await _bookReviewRepository.UpdateBookReview(bookReviewId, bookReview);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return review;
    }

    public async Task<bool> DeleteBookReview(Guid bookReviewId, CancellationToken cancellationToken = default)
    {
        if (!await _sharedBookManagementRepository.IsBookReviewExistsByBookReviewId(bookReviewId))
            throw new NotFoundException("book review not found");
        var result = await _bookReviewRepository.DeleteBookReview(bookReviewId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<List<Response<BookReview>>> GetAllBookReviewByBookIdAndUserId(Guid userId, Guid bookId)
    {
        if (!await _sharedBookManagementRepository.IsBookExistsByBookId(bookId))
            throw new NotFoundException("book  not found");
        if (!await _sharedUserRepository.IsUserExistsUserId(userId))
            throw new NotFoundException("user not found");
        return await _bookReviewRepository.GetAllBookReviewByBookIdAndUserId(userId, bookId);
    }
}