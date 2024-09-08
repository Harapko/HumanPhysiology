using AutoMapper;
using HumPsi.Application.Section.Commands.CreateSectionCommand;
using HumPsi.Application.Section.Commands.UpdateSectionCommand;
using HumPsi.Application.Section.Queries.GetAllSectionQuery;
using HumPsi.Domain.Entities;

namespace HumPsi.Application.Mapping.Section;

public class SectionMapping : Profile
{
    public SectionMapping()
    {
        CreateMap<SectionEntity, GetSectionDtoResponse>()
            .ForMember(des => des.id,
                src => src.MapFrom(s => s.Id))
            .ForMember(des => des.sectionName,
                src => src.MapFrom(s => s.SectionName));
        
        CreateMap<CreateSectionDtoRequest, SectionEntity>()
            .ForMember(des => des.Id,
                src => src.MapFrom(s => Guid.NewGuid()))
            .ForMember(des => des.SectionName,
                src => src.MapFrom(s => s.title));
        
        CreateMap<UpdateSectionDtoRequest, SectionEntity>()
            .ForMember(des => des.Id,
                src => src.MapFrom(s => s.id))
            .ForMember(des => des.SectionName,
                src => src.MapFrom(s => s.sectionName));
    }
}