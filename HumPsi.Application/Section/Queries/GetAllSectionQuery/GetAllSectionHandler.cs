using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HumPsi.Application.Section.Queries.GetAllSectionQuery;

public class GetAllSectionHandler(ISectionRepository repository) : IRequestHandler<GetAllSectionQuery, List<SectionEntity>>
{
    public async Task<List<SectionEntity>> Handle(GetAllSectionQuery request, CancellationToken cancellationToken)
    {
        var sectionList = await repository.GetSection();

        return sectionList;
    }
}