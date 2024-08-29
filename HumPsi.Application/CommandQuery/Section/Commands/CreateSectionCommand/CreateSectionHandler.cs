using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Commands.CreateSectionCommand;

public class CreateSectionHandler(ISectionRepository repository) : IRequestHandler<CreateSectionCommand, SectionEntity>
{
    public async Task<SectionEntity> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        var section = new SectionEntity
        {
            Id = request.Id,
            SectionName = request.title
        };

        var result = await repository.CreateSection(section);
        return result;
    }
}