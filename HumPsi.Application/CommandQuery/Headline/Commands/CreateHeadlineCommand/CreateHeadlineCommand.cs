using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public record CreateHeadlineCommand(string title, IFormFile file, Guid sectionId) : IRequest<HeadlineEntity>
{
    public Guid Id { get; } = Guid.NewGuid();
}