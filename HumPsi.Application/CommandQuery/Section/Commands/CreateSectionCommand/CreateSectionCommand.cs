using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Commands.CreateSectionCommand;

public record CreateSectionCommand(SectionEntity section) : IRequest<(int code, string text)>;