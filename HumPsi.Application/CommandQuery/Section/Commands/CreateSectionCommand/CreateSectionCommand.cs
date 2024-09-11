using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Commands.CreateSectionCommand;

public record CreateSectionCommand(CreateSectionDtoRequest request) : IRequest<(int code, string text)>;