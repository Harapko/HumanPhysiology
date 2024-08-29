using AutoMapper;
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
    }
}