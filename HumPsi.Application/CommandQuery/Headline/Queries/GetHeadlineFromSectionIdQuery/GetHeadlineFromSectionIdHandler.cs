using AutoMapper;
using HumPsi.Application.Headline.Queries;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Headline.Queries.GetHeadlineFromSectionIdQuery;

public class GetHeadlineFromSectionIdHandler(IHeadlineRepository repository, IMapper mapper) : IRequestHandler<GetHeadlineFromSectionIdQuery, List<GetHeadlineDtoResponse>>
{
    public async Task<List<GetHeadlineDtoResponse>> Handle(GetHeadlineFromSectionIdQuery request, CancellationToken cancellationToken)
    {
        var headline = await repository.GetHeadlineFromSectionId(request.sectionId);

        if (headline.Count == 0)
            return [];

        var result = mapper.Map<List<GetHeadlineDtoResponse>>(headline);

        return result;
    }
}