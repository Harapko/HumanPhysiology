using MediatR;

namespace HumPsi.Application.Command_Query.Headline.Commands.DeleteHeadlineCommand;

public record DeleteHeadlineCommand(Guid id) : IRequest<Guid>;