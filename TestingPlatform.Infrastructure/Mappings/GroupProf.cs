using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Mappings;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<Groups, GroupDto>();
        CreateMap<GroupDto, Groups>()
            .ForMember(d => d.Course, o => o.Ignore())
            .ForMember(d => d.Direction, o => o.Ignore())
            .ForMember(d => d.Project, o => o.Ignore());
    }
}