using HumPsi.Domain.Abstraction.IRepositories;
using MediatR;

namespace HumPsi.Application.Command_Query.Headline.Commands.DeleteHeadlineCommand;

public class DeleteHeadlineHandler(IHeadlineRepository repository) : IRequestHandler<DeleteHeadlineCommand, Guid>
{
    public async Task<Guid> Handle(DeleteHeadlineCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteHeadline(request.id);
        return result;
    }
}