using Domain.DTOs.OrderDTOs;
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

    public async Task<List<Response<PatronProfile>>> GetPatronProfile(Guid userId)
    {
        return await _libraryDbContext.Orders
            .AsNoTracking()
            .Include(x => x.OrderItems)
            .Where(x => x.UserId == userId)
            .Select(x => new Response<PatronProfile>(x.Adapt<PatronProfile>(), x.Id))
            .ToListAsync();
    }

    public async Task<PatronProfile> ViewAndEditPatronProfile(PatronProfile patronProfile, Guid orderId)
    {
        var order = await _libraryDbContext.Orders
                        .Where(x => x.UserId == patronProfile.UserId)
                        .FirstOrDefaultAsync(x => x.Id == orderId)
                    ?? throw new NotFoundException("order not found");
        _libraryDbContext.Orders.Update(patronProfile.Adapt(order));
        return patronProfile;
    }
}