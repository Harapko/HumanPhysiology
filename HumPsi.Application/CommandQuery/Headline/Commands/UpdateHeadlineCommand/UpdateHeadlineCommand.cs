using MediatR;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;

public record UpdateHeadlineCommand(Guid Id, string Title, IFormFile File) : IRequest<Guid>;
