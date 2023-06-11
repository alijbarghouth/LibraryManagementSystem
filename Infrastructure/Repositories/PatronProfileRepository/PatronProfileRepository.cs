using Domain.DTOs.PatronProfileDTOs;
using Domain.DTOs.Response;
using Domain.Repositories.PatronProfileRepository;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PatronProfileRepository;

public sealed class PatronProfileRepository : IPatronProfileRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public PatronProfileRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<List<PatronProfile>> GetPatronProfile(Guid userId)
    {
        return await _libraryDbContext.Orders
            .AsNoTracking()
            .Include(x => x.OrderItems)
            .Where(x => x.UserId == userId)
            .Select
            (x =>
                x.Adapt<PatronProfile>()
            )
            .ToListAsync();
    }

    public async Task<PatronProfile> ViewAndEditPatronProfile
        (PatronProfile patronProfile)
    {
        var order = await _libraryDbContext.Orders
            .Include(x => x.OrderItems)
            .FirstOrDefaultAsync(x => x.Id == patronProfile.Id);

        _libraryDbContext.Orders.Update(patronProfile.Adapt(order));
        return patronProfile;
    }
}