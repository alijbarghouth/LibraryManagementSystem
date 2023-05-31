﻿using Domain.Features.UserService.DTOs;

namespace Domain.Features.UserService.Services.AuthService;

public interface IAuthService
{
    Task<bool> AddRole(RoleRequest role, CancellationToken cancellationToken = default);
}