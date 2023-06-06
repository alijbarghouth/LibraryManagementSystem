using Domain.DTOs.Response;
using Domain.Repositories.ReadingListRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ReadingListRepository;

public sealed class ReadingListRepository : IReadingListRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public ReadingListRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Response<Domain.DTOs.ReadingListDTOs.ReadingList>> AddReadingList
        (Domain.DTOs.ReadingListDTOs.ReadingList readingList)
    {
        var list = readingList.Adapt<ReadingList>();
        await _libraryDbContext.ReadingLists
            .AddAsync(list);
        return new Response<Domain.DTOs.ReadingListDTOs.ReadingList>
            (readingList, list.Id);
    }

    public async Task<bool> DeleteReadingList(Guid readingListId)
    {
        var readList = await _libraryDbContext.ReadingLists
            .FindAsync(readingListId);
        _libraryDbContext.ReadingLists.Remove(readList);
        return true;
    }

    public async Task<List<Domain.DTOs.ReadingListDTOs.ReadingListResponse>> GetAllReadingList(Guid userId)
    {
        return (await _libraryDbContext.ReadingLists
                .Include(x => x.Book)
                .Include(x => x.Book.Genre)
                .Include(x => x.Book.Authors)
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => new
                {
                    x.UserId,
                    x.BookId,
                    BookName = x.Book.Title,
                    Genres = x.Book.Genre
                        .ToList(),
                    Authors = x.Book.Authors
                        .ToList(),
                    x.Book.BookStatus
                })
                .ToListAsync())
            .Adapt<List<Domain.DTOs.ReadingListDTOs.ReadingListResponse>>();
    }
}