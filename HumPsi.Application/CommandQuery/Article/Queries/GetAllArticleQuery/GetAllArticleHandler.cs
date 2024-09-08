using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Queries.GetAllArticleQuery;

public class GetAllArticleHandler(IArticleRepository repository) : IRequestHandler<GetAllArticleQuery, List<ArticleEntity>>
{
    public async Task<List<ArticleEntity>> Handle(GetAllArticleQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.Get();

        if (result.Count == 0)
            return [];

        return result;
    }
}