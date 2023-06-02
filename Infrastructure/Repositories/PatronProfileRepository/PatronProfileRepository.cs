using Domain.DTOs.OrderDTOs;
using Domain.DTOs.PatronProfileDTOs;
using Domain.Repositories.PatronProfileRepository;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PatronProfileRepository;

public class PatronProfileRepository : IPatronProfileRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public PatronProfileRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<List<PatronProfile>> GetPatronProfile(Guid userId)
    {
        return (await _libraryDbContext.Orders
            .AsNoTracking()
            .Include(x => x.OrderItems)
            .Where(x => x.UserId == userId)
            .ToListAsync()).Adapt<List<PatronProfile>>();
    }

    public Task<PatronProfile> ViewAndEditPatronProfile(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<PatronProfile> ViewAndEditPatronProfile(PatronProfile patronProfile, Guid orderId)
    {
        var order = await _libraryDbContext.Orders
                        .Where(x => x.UserId == patronProfile.UserId)
                        .FirstOrDefaultAsync(x => x.Id == orderId)
                    ?? throw new NotFoundException("order not found");
        order.Adapt(patronProfile);
        _libraryDbContext.Orders.Update(order);
        return patronProfile;
    }
}