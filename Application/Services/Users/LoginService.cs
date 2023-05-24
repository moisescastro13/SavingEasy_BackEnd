using Application.Interfaces.Common;
using Application.Interfaces;
using AutoMapper;
using Application.interfaces.Authorization;
using Application.Models.JWT;
using Application.Dto.User;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Users;

namespace Application.Services.Users;

public class LoginService : ILoginService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJWTTokenService _jwtTokenService;

    public LoginService(IApplicationDbContext context, IMapper mapper, IPasswordHasher passwordHasher, IJWTTokenService jwtTokenService)
    {
        _context = context;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<JwtToken> Authenticate(AuthenticationDto authenticationDto, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(
                x => x.Email == authenticationDto.Email || x.UserName == authenticationDto.UserName,
                cancellationToken
                );

        if (user is null)
        {
            throw new Exception("Nel perro");
        }

        var isValidPassword = _passwordHasher.Verify(authenticationDto.Password, user.Password);
        if (!isValidPassword)
        {
            throw new Exception("Nel perro");
        }

        var token = _jwtTokenService.Authenticate(user);
        if (token is null)
        {
            throw new Exception();
        }

        return token;
    }
}
