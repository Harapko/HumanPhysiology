using AutoMapper;
using HumPsi.Application.CommandQuery.Article.Queries.GetAllArticleQuery;
using HumPsi.Domain.Abstraction.IRepositories;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Queries.GetArticleForHeadlineIdQuery;

public class GetArticleFromHeadlineHandler(IArticleRepository repository, IMapper mapper) : IRequestHandler<GetArticleFromHeadlineIdQuery, List<GetArticleDtoResponse>>
{
    public async Task<List<GetArticleDtoResponse>> Handle(GetArticleFromHeadlineIdQuery request, CancellationToken cancellationToken)
    {
        var article = await repository.GetFromHeadlineId(request.headlineId);

        if (article.Count == 0)
            return [];

        var result = mapper.Map<List<GetArticleDtoResponse>>(article);

        return result;
    }
}