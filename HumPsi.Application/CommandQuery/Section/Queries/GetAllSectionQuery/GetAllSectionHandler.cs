using AutoMapper;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Queries.GetAllSectionQuery;

public class GetAllSectionHandler(ISectionRepository repository, IMapper mapper) : IRequestHandler<GetAllSectionQuery, List<GetSectionDtoResponse>>
{
    public async Task<List<GetSectionDtoResponse>> Handle(GetAllSectionQuery request, CancellationToken cancellationToken)
    {
        var sectionList = await repository.GetSection();

        var result = mapper.Map<List<GetSectionDtoResponse>>(sectionList);

        return result;
    }
}