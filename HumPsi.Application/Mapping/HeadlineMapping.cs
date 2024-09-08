using AutoMapper;
using HumPsi.Application.Headline.Commands.CreateHeadlineCommand;
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
                src => src.MapFrom(h => h.PhotoPath))
            .ForMember(des => des.sectionId,
                src => src.MapFrom(h => h.SectionId));
        
        CreateMap<CreateHeadlineDtoRequest, HeadlineEntity>()
            .ForMember(des => des.Id,
                src => src.MapFrom(h => Guid.NewGuid()))
            .ForMember(des => des.Title,
                src => src.MapFrom(h => h.title))
            .ForMember(des => des.SectionId,
                src => src.MapFrom(h => h.sectionId));
        
        CreateMap<UpdateHeadlineDtoRequest, HeadlineEntity>()
            .ForMember(des => des.Id,
                src => src.MapFrom(h => h.id))
            .ForMember(des => des.Title,
                src => src.MapFrom(h => h.title))
            .ForMember(des => des.PhotoPath,
                src => src.MapFrom(h => h.file))
            .ForMember(des => des.SectionId,
                src => src.MapFrom(h => h.sectionId));
    }
}