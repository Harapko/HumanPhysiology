using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Queries.GetAllArticleQuery;

public class GetAllArticleQuery : IRequest<List<ArticleEntity>>
{
    
}