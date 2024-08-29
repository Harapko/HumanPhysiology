using MediatR;

namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public record UpdateSectionCommand(Guid id, string sectionName) : IRequest<Guid>{}