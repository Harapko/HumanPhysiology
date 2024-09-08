using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Headline.Queries.GetHeadlineFromSectionIdQuery;

public record GetHeadlineFromSectionIdQuery(Guid sectionId) : IRequest<List<HeadlineEntity>>;