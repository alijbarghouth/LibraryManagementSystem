using Domain.DTOs.UserDTOs;
using Domain.Repositories.UserRepositories;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Infrastructure.HashingPassword;
using Mapster;
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

    public async Task<UpdateLibrarianRequest> UpdateLibrarianAccount(Guid userId,
        UpdateLibrarianRequest updateLibrarianRequest)
    {
        var librarian = await _libraryDbContext.Users
                            .FindAsync(userId)
                        ?? throw new NotFoundException("user not found");
        if (librarian.Roles.SingleOrDefault(x => x.RoleName == "Librarian") is null)
        {
            throw new NotFoundException("user not Librarian");
        }

        updateLibrarianRequest.Adapt(librarian);
        updateLibrarianRequest.Password.HashingPassword(out byte[] passwordHash, out byte[] passwordSlot);
        librarian.PasswordHash = passwordHash;
        librarian.PasswordSlot = passwordSlot;
        _libraryDbContext.Users.Update(librarian);
        return updateLibrarianRequest;
    }

    public async Task<bool> DeleteLibrarianAccount(Guid userId)
    {
        var user = await _libraryDbContext.Users
                       .FindAsync(userId)
                   ?? throw new NotFoundException("user not found");
        if (user.Roles.SingleOrDefault(x => x.RoleName == "Librarian") is null)
            throw new NotFoundException("user not Librarian");
        _libraryDbContext.Users
            .Remove(user);
        return true;
    }
}