using AutoMapper;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;

public class CreateArticleHandler(IArticleRepository repository, IMapper mapper) : IRequestHandler<CreateArticleCommand, (int code, string text)>
{
    public async Task<(int code, string text)> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = mapper.Map<ArticleEntity>(request.request);
        
        var result = await repository.CreateArticle(article, request.request.file);
        
        return result;
    }
}