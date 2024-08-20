using MediatR;

namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public class UpdateSectionCommand(Guid id, string sectionName) : IRequest<Guid>
{
    public Guid Id { get; } = id;
    public string SectionName { get; } = sectionName;
}