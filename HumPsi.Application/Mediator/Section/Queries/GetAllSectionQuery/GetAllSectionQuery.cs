using HumPsi.Application.Mediator.Base.Query;
using HumPsi.Application.Section.Queries.GetAllSectionQuery;
using MediatR;

namespace HumPsi.Application.Mediator.Section.Queries.GetAllSectionQuery;

public record GetAllSectionQuery : BaseGetAllQuery<GetSectionDtoResponse>;