using AutoMapper;
using HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;
using HumPsi.Application.Headline.Queries;
using HumPsi.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Mapping.Section;

public class HeadlineMapping : Profile
{
    public HeadlineMapping()
    {
        CreateMap<HeadlineEntity, GetHeadlineDtoResponse>()
            .ForMember(des => des.id,
                src => src.MapFrom(h => h.Id))
            .ForMember(des => des.title,
                src => src.MapFrom(h => h.Title))
            .ForMember(des => des.photoPath,
                src => src.MapFrom(h => h.PhotoPath));
        
    }
}