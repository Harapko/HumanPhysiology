using AutoMapper;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Headline.Queries;

public class GetAllHeadlineHandler(IHeadlineRepository repository, IMapper mapper) : IRequestHandler<GetAllHeadlineQuery, List<GetHeadlineDtoResponse>>
{
    public async Task<List<GetHeadlineDtoResponse>> Handle(GetAllHeadlineQuery request, CancellationToken cancellationToken)
    {
        var headlines = await repository.GetHeadline();
        
        var result = mapper.Map<List<GetHeadlineDtoResponse>>(headlines);
        
        return result;
    }
}