using AutoMapper;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public class CreateHeadlineHandler(IHeadlineRepository repository, IMapper mapper) : IRequestHandler<CreateHeadlineCommand, (int code, string text)>
{
    public async Task<(int code, string text)> Handle(CreateHeadlineCommand request, CancellationToken cancellationToken)
    {
        var headline = mapper.Map<HeadlineEntity>(request.request);
        
        var result = await repository.CreateHeadline(request.file, headline);

        return result;
    }
}