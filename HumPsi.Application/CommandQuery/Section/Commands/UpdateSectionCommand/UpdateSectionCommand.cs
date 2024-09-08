using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public record UpdateSectionCommand(SectionEntity section) : IRequest<(int code, string text)>{}