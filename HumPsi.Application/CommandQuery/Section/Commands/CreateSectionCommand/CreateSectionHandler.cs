using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Commands.CreateSectionCommand;

public class CreateSectionHandler(ISectionRepository repository) : IRequestHandler<CreateSectionCommand, (int code, string text)>
{
    public async Task<(int code, string text)> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.CreateSection(request.section);
        return result;
    }
}