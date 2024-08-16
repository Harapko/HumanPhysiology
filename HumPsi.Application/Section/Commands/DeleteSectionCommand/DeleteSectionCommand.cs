using MediatR;

namespace HumPsi.Application.Section.Commands.DeleteSectionCommand;

public class DeleteSectionCommand(Guid id) : IRequest<Guid>
{
    public Guid Id { get; } = id;
}