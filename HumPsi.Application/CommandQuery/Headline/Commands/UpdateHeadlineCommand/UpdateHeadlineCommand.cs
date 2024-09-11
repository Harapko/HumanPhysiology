using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;

public record UpdateHeadlineCommand(UpdateHeadlineDtoRequest request, IFormFile? File) : IRequest<(int code, string text)>;
