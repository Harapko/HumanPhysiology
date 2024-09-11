using AutoMapper;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Commands.UpdateArticleCommand;

public class UpdateArticleHandler(IArticleRepository repository, IMapper mapper) : IRequestHandler<UpdateArticleCommand, (int code, string text)>
{
    public async Task<(int code, string text)> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = mapper.Map<ArticleEntity>(request.request);

        var result = await repository.UpdateArticle(article, request.request.file);

        return result;
    }
}