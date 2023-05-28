using Application.Features.UserFeature.Command;
using Application.Features.UserFeature.Validator;
using Domain.Features.UserService.DTOs;
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
        services.AddScoped<IValidator<User>, UserValidation>();
    }
    private static void AddCustomDependencies(IServiceCollection services)
    {
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<ICommandService, CommandService>();
        services.AddScoped<ILoginService, LoginService>();
    }
}
