using Domain.DTOs.UserDTOs;
using Domain.Repositories.UserRepositories;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepositories;

public sealed class AuthRepository : IAuthRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public AuthRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task AddRole(RoleRequest roleRequest)
    {
        var user = await _libraryDbContext.Users.FindAsync(roleRequest.UserId)
            ?? throw new NotFoundException("user not found");
        var role = await _libraryDbContext.Roles.FirstOrDefaultAsync(x => x.RoleName == roleRequest.RoleName)
            ?? throw new NotFoundException("role not found");
        if (user.Roles.Any(x => x.RoleName == roleRequest.RoleName))
        {
            throw new BadRequestException("User already assigned to this role");
        }

        user.Roles.Add(role);
        _libraryDbContext.Users.Update(user);
    }
}
