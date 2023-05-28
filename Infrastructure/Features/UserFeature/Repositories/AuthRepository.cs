using Domain.Features.UserService.DTOs;
using Domain.Features.UserService.Services.AuthService;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Features.UserFeature.Repositories;

public sealed class AuthRepository : IAuthRepository
{
    private readonly LibraryDBContext _libraryDBContext;

    public AuthRepository(LibraryDBContext libraryDBContext)
    {
        _libraryDBContext = libraryDBContext;
    }

    public async Task AddRole(RoleRequest roleRequest)
    {
        var user = await _libraryDBContext.Users.FindAsync(roleRequest.UserId)
            ?? throw new LibraryNotFoundException("user not found");
        var role = await _libraryDBContext.Roles.FirstOrDefaultAsync(x => x.RoleName == roleRequest.RoleName)
            ?? throw new LibraryNotFoundException("role not found");
        if(user.Roles.Any(x => x.RoleName == roleRequest.RoleName))
        {
            throw new LibraryBadRequestException("User already assigned to this role");
        }

        user.Roles.Add(role);
        _libraryDBContext.Users.Update(user);
    }
}
