using MediatR;

namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public record UpdateSectionCommand(UpdateSectionDtoRequest request) : IRequest<(int code, string text)>{}