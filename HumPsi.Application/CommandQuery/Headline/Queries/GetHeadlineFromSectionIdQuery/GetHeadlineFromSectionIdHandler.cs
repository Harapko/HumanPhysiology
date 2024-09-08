using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Headline.Queries.GetHeadlineFromSectionIdQuery;

public class GetHeadlineFromSectionIdHandler(ISectionRepository repository) : IRequestHandler<GetHeadlineFromSectionIdQuery, List<HeadlineEntity>>
{
    public Task<List<HeadlineEntity>> Handle(GetHeadlineFromSectionIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}