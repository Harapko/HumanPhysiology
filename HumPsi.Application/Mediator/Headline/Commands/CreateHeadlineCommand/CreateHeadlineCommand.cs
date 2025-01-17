using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public record CreateHeadlineCommand(IFormFile? file, CreateHeadlineDtoRequest request) : IRequest<(int code, string text)>;