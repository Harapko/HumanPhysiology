using HumPsi.Domain.Abstraction.IRepositories;
using MediatR;

namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public class UpdateSectionHandler(ISectionRepository repository) : IRequestHandler<UpdateSectionCommand, (int code, string text)>
{
    public async Task<(int code, string text)> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.UpdateSection(request.section);

        return result;
    }
}