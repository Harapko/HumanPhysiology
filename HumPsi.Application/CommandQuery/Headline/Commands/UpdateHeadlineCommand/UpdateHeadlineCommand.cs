using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;

public record UpdateHeadlineCommand(HeadlineEntity headline, IFormFile? File) : IRequest<(int code, string text)>;
