using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Headline.Queries;

public class GetAllHeadlineHandler(IHeadlineRepository repository) : IRequestHandler<GetAllHeadlineQuery, List<HeadlineEntity>>
{
    public async Task<List<HeadlineEntity>> Handle(GetAllHeadlineQuery request, CancellationToken cancellationToken)
    {
        var headlines = await repository.GetHeadline();
        return headlines;
    }
}