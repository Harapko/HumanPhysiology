using AutoMapper;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Queries.GetAllSectionQuery;

public class GetAllSectionHandler(IRepositoryWrapper _repositoryWrapper, IMapper mapper) : IRequestHandler<Mediator.Section.Queries.GetAllSectionQuery.GetAllSectionQuery, IEnumerable<GetSectionDtoResponse>>
{
    public async Task<IEnumerable<GetSectionDtoResponse>> Handle(Mediator.Section.Queries.GetAllSectionQuery.GetAllSectionQuery request, CancellationToken cancellationToken)
    {
        return [];
    }
}