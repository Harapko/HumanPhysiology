using AutoMapper;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Queries.GetAllArticleQuery;

public class GetAllArticleHandler(IArticleRepository repository, IMapper mapper) : IRequestHandler<GetAllArticleQuery, List<GetArticleDtoResponse>>
{
    public async Task<List<GetArticleDtoResponse>> Handle(GetAllArticleQuery request, CancellationToken cancellationToken)
    {
        var article = await repository.Get();

        if (article.Count == 0)
            return [];

        var result = mapper.Map<List<GetArticleDtoResponse>>(article);

        return result;
    }
}