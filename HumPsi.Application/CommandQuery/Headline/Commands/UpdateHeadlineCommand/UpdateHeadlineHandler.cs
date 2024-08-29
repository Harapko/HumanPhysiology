using HumPsi.Domain.Abstraction.IRepositories;
using MediatR;

namespace HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;

public class UpdateHeadlineHandler(IHeadlineRepository repository) : IRequestHandler<UpdateHeadlineCommand, Guid>
{
    public async Task<Guid> Handle(UpdateHeadlineCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.UpdateHeadline(request.Id, request.Title, request.File);
        return result;
    }
}