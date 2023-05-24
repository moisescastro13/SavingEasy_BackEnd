using Application.Interfaces.BoxSavings;
using Application.Interfaces.Common;
using Application.Interfaces.Users;
using Application.Services.BoxSavings;
using Application.Services.Hasher;
using Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IUserRegisterService,UserRegisterService>();
        services.AddScoped<ICreateBoxSavingService, CreateBoxSavingService>();
        services.AddScoped<IUpdateBoxSavingService, UpdateBoxSavingService>();
        return services;
    }
}
