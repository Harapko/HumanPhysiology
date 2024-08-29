using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Commands.CreateSectionCommand;

public record CreateSectionCommand(string title) : IRequest<SectionEntity>
{
    public Guid Id { get; } = Guid.NewGuid();
}