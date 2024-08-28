using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public class CreateHeadlineCommand(string title, IFormFile file, Guid sectionId) : IRequest<HeadlineEntity>
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; } = title;
    public IFormFile File { get; } = file;
    public Guid SectionId { get; } = sectionId;
}