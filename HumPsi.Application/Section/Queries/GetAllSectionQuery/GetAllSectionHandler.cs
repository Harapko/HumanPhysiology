using HumPsi.Domain;
using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HumPsi.Application.Section.Queries.GetAllSectionQuery;

public class GetAllSectionHandler(AppDbContext context) : IRequestHandler<GetAllSectionQuery, List<SectionEntity>>
{
    public async Task<List<SectionEntity>> Handle(GetAllSectionQuery request, CancellationToken cancellationToken)
    {
        var sectionList = await context.Section
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return sectionList;
    }
}