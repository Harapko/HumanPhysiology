using HumPsi.Domain;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Commands.CreateSectionCommand;

public class CreateSectionHandler(AppDbContext context) : IRequestHandler<CreateSectionCommand, SectionEntity>
{
    public async Task<SectionEntity> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        var section = new SectionEntity
        {
            Id = request.Id,
            SectionName = request.Title
        };

        await context.Section.AddAsync(section, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return section;
    }
}