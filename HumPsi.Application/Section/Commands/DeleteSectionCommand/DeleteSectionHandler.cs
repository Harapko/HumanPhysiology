using HumPsi.Domain.Abstraction.IRepositories;
using MediatR;

namespace HumPsi.Application.Section.Commands.DeleteSectionCommand;

public class DeleteSectionHandler(ISectionRepository repository) : IRequestHandler<DeleteSectionCommand, Guid>
{
    public async Task<Guid> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteSection(request.Id);

        return result;
    }
}