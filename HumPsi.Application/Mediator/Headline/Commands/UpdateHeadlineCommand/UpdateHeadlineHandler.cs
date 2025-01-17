using AutoMapper;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;

public class UpdateHeadlineHandler(IHeadlineRepository repository, IMapper mapper) : IRequestHandler<UpdateHeadlineCommand, (int code, string text)>
{
    public async Task<(int code, string text)> Handle(UpdateHeadlineCommand request, CancellationToken cancellationToken)
    {
        var headline = mapper.Map<HeadlineEntity>(request.request);
        
        var result = await repository.UpdateHeadline(headline, request.File);
        
        return result;
    }
}