using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Queries.GetArticleForHeadlineIdQuery;

public class GetArticleFromHeadlineHandler(IArticleRepository repository) : IRequestHandler<GetArticleFromHeadlineIdQuery, List<ArticleEntity>>
{
    public async Task<List<ArticleEntity>> Handle(GetArticleFromHeadlineIdQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetFromHeadlineId(request.headlineId);

        if (result.Count == 0)
            return [];

        return result;
    }
}