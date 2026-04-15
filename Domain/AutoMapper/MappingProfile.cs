using AutoMapper;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Users, UserDto>().ReverseMap();
    }
}