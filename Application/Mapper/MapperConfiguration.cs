
using Application.Dto.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<CreateUserInformationDto, UserInformation>();

        CreateMap<User, ReadUserDto>().ForMember(x => x.Id, x => x.MapFrom(y => y.Id.value));
    }
}
