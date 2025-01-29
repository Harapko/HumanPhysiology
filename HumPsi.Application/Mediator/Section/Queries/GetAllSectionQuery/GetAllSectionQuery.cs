using HumPsi.Application.Section.Queries.GetAllSectionQuery;
using MediatR;

namespace HumPsi.Application.Mediator.Section.Queries.GetAllSectionQuery;

public record GetAllSectionQuery : IRequest<List<GetSectionDtoResponse>>;