using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public record CreateHeadlineCommand(IFormFile? file, HeadlineEntity headline) : IRequest<(int code, string text)>;