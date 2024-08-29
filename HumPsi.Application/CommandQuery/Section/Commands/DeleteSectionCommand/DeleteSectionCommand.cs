using MediatR;

namespace HumPsi.Application.Section.Commands.DeleteSectionCommand;

public record DeleteSectionCommand(Guid id) : IRequest<Guid>
{
}