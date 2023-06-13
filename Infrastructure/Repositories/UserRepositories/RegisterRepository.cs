using Domain.DTOs.Response;
using Domain.DTOs.UserDTOs;
using Domain.Repositories.UserRepositories;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Infrastructure.Utils;
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

    public async Task<Response<RegisterUser>>
        RegisterUser(RegisterUser register)
    {
        var role = await _libraryDbContext.Roles.FirstOrDefaultAsync(x => x.RoleName == "Patrons");

        register.Password.HashingPassword(out var passwordHash, out var passwordSlot);
        var user = register.Adapt<User>();
        user.PasswordHash = passwordHash;
        user.PasswordSlot = passwordSlot;

        user.Roles.Add(role);
        await _libraryDbContext.Users.AddAsync(user);

        return new Response<RegisterUser>(register,user.Id);
    }
}
