using Application.Features.UserFeature.Command;
using Application.Features.UserFeature.Handler.LoginHandler;
using Application.Features.UserFeature.Handler.RefreshTokenHandler;
using Application.Features.UserFeature.Handler.RegisterHandler;
using Application.Features.UserFeature.Handler.RoleHandler;
using Application.Features.UserFeature.Validator;
using Domain.Features.UserService.Services.AuthService;
using Domain.Features.UserService.Services.LoginService;
using Domain.Features.UserService.Services.RegisterService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations;

public static class Configuration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        AddFluentValidation(services);
        AddCustomDependencies(services);
        return services;
    }
    private static void AddFluentValidation(IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddScoped<IValidator<RegisterUserCommand>, UserValidation>();
    }
    private static void AddCustomDependencies(IServiceCollection services)
    {
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRegisterUserCommandHandler, RegisterUserCommandHandler>();
        services.AddScoped<ILoginUserCommandHandler, LoginUserCommandHandler>();
        services.AddScoped<IRoleCommandHandler, RoleCommandHandler>();
        services.AddScoped<IRefreshTokenQueryHandler, RefreshTokenQueryHandler>();
    }
}
