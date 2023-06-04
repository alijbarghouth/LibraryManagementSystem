using Domain.DTOs.UserDTOs;
using Domain.Repositories.UserRepositories;
using Infrastructure.DBContext;
using Infrastructure.HashingPassword;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepositories;

public sealed class RegisterRepository : IRegisterRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public RegisterRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<RegisterUser>
        RegisterUser(RegisterUser register)
    {
        var role = await _libraryDbContext.Roles.FirstOrDefaultAsync(x => x.RoleName == "Patrons");

        register.Password.HashingPassword(out byte[] passwordHash, out byte[] passwordSlot);
        var user = register.Adapt<User>();
        user.PasswordHash = passwordHash;
        user.PasswordSlot = passwordSlot;

        user.Roles.Add(role);
        await _libraryDbContext.Users.AddAsync(user);

        return register;
    }
}
