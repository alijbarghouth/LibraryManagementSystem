using Domain.DTOs.OrderDTOs;
using Domain.DTOs.PatronProfileDTOs;
using Domain.Repositories.PatronProfileRepository;
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
            .Include(x => x.OrderItems)
            .Where(x => x.UserId == userId)
            .ToListAsync()).Adapt<List<PatronProfile>>();
    }
}