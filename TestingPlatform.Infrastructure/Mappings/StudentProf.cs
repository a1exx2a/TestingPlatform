using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Mappings;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Students, StudentDto>()
            .ForMember(d => d.User, m => m.MapFrom(s => s.User));

        CreateMap<StudentDto, Students>()
            .ForMember(d => d.User, m => m.Ignore());
    }
}