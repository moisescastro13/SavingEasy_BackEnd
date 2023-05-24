
using Infrastructure.JWT.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.JWT.extensions;

public static class ExtesionsJwt
{
    public static IServiceCollection ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        var jwtOptions =  configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

        services.AddAuthentication(k =>
        {
            k.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            k.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(p =>
        {
            var key = Encoding.UTF8.GetBytes(jwtOptions!.SecretKey);
            p.SaveToken = true;
            p.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.SecretKey,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
            
        });

        //services.AddScoped<IJWTTokenServices, JWTServiceManage>();
        return services;
    } 
}
