using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Queries.GetAllSectionQuery;

public class GetAllSectionQuery : IRequest<List<SectionEntity>>
{
    
}