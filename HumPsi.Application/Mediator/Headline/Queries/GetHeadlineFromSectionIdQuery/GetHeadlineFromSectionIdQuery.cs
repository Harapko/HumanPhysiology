using HumPsi.Application.Headline.Queries;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Headline.Queries.GetHeadlineFromSectionIdQuery;

public record GetHeadlineFromSectionIdQuery(Guid sectionId) : IRequest<List<GetHeadlineDtoResponse>>;