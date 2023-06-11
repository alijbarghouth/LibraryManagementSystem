using Domain.Repositories.ModerationRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ModerationRepository;

public class ModerationRepository : IModerationRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public ModerationRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<bool> DeleteReview(string massage, Guid bookReviewId)
    {
        var review = await _libraryDbContext.BookReviews
            .Include(x=> x.Moderations)
            .FirstAsync(x => x.Id == bookReviewId);
        var moderation = new Moderation
        {
            BookReviewId = review.Id,
            Reason = massage,
            IsApproved = false
        };
        review.Moderations.Add(moderation);
        _libraryDbContext.BookReviews.Update(review);
        return true;
    }
}