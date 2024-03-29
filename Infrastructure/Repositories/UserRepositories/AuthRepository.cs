﻿using Domain.DTOs.UserDTOs;
using Domain.Repositories.UserRepositories;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Infrastructure.Utils;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepositories;

public sealed class AuthRepository : IAuthRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public AuthRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task AddRole(RoleRequest roleRequest)
    {
        var user = await _libraryDbContext.Users
            .Include(x=>x.Roles)
            .SingleAsync(x=> x.Id == roleRequest.UserId);

        var role = await _libraryDbContext.Roles.FirstOrDefaultAsync
                       (x => x.RoleName == roleRequest.RoleName)
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
            .FindAsync(userId);
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
            .FindAsync(userId);
        if (user.Roles.SingleOrDefault(x => x.RoleName == "Librarian") is null)
            throw new NotFoundException("user not Librarian");
        user.IsActive = false;
        _libraryDbContext.Users
            .Update(user);
        return true;
    }

    public async Task ResetPassword(ResetPassword resetPassword)
    {
        var user = await _libraryDbContext.Users
            .SingleAsync(x => x.Email == resetPassword.Email);
        if (!resetPassword.CurrentPassword.VerifyingPassword
                (user.PasswordHash, user.PasswordSlot))
            throw new BadRequestException("password is not correct");
        resetPassword.NewPassword.HashingPassword(out var passwordHash, out var passwordSlot);
        user.PasswordHash = passwordHash;
        user.PasswordSlot = passwordSlot;
        _libraryDbContext.Users.Update(user);
    }

    public async Task DeleteAccount(Guid userId)
    {
        var user = await _libraryDbContext.Users
            .FindAsync(userId);
        user.IsActive = false;
        _libraryDbContext.Users.Update(user);
    }
}