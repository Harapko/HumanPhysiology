using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Queries.GetAllSectionQuery;

public record GetAllSectionQuery : IRequest<List<GetSectionDtoResponse>>
{
    
}