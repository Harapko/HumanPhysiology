using HumPsi.Domain.Abstraction.IRepositories;
using MediatR;

namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public class UpdateSectionHandler(ISectionRepository repository) : IRequestHandler<UpdateSectionCommand, Guid>
{
    public async Task<Guid> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.UpdateSection(request.Id, request.SectionName);

        return result;
    }
}