
using Application.Dto.User;
using Application.Interfaces;
using Application.Interfaces.Common;
using Application.Interfaces.Users;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Users;

public class UserRegisterService : IUserRegisterService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    public UserRegisterService(IApplicationDbContext context, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _context = context;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<ReadUserDto?> Register(CreateUserDto createUserDto, CancellationToken cancellationToken = default)
    {
        var userExist = await _context.Users.AnyAsync(x => x.UserName == createUserDto.UserName || x.Email == createUserDto.Email);
        if (userExist)
        {
            throw new ApplicationException($"Username {createUserDto.UserName} or {createUserDto.Email} is already exist");
        }
        createUserDto.Password = _passwordHasher.Hash(createUserDto.Password);

        var user = User.Create(createUserDto.UserName, createUserDto.Password, createUserDto.Email);


        var information = createUserDto.informationDto;
            _context.Users.Add(user);

        if(information is not null)
        {
            user.AddUserInformation(information.FirstName, information.LastName, information.Address, information.PhoneNumber);
        }
        
        await _context.SaveChangesAsync(cancellationToken);

        var userDto = _mapper.Map<ReadUserDto>(user);
        return userDto;
    }
}
