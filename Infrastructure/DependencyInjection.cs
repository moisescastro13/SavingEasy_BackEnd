
using Application.interfaces.Authorization;
using Application.Interfaces;
using Infrastructure.JWT.extensions;
using Infrastructure.JWT.Services;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.ConfigureJwt(configuration);
        services.AddScoped<IJWTTokenService, JwtServiceManage>();

        return services;
    }
}
