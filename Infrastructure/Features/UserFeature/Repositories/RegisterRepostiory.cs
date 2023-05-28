using Domain.Features.UserService.Services.RegisterService;
using Infrastructure.DBContext;
using Infrastructure.HashingPassword;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Features.UserFeature.Repositories;

public sealed class RegisterRepostiory : IRegisterRepository
{
    private readonly LibraryDBContext _libraryDBContext;

    public RegisterRepostiory(LibraryDBContext libraryDBContext)
    {
        _libraryDBContext = libraryDBContext;
    }

    public async Task<Domain.Features.UserService.DTOs.User>
        RegisterUser(Domain.Features.UserService.DTOs.User register)
    {
        var role = await _libraryDBContext.Roles.FirstOrDefaultAsync(x => x.RoleName == "Patrons");

        register.Password.HashingPassword(out byte[] passwordHash, out byte[] passwordSlot);
        var user = register.Adapt<User>();
        user.PasswordHash = passwordHash;
        user.PasswordSlot = passwordSlot;

        user.Roles.Add(role);
        await _libraryDBContext.Users.AddAsync(user);

        return register;
    }
}
