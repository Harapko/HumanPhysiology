using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Queries.GetArticleForHeadlineIdQuery;

public record GetArticleFromHeadlineIdQuery(Guid headlineId) : IRequest<List<ArticleEntity>>;
