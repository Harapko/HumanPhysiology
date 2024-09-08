using HumPsi.Domain.Abstraction.IRepositories;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;

public class CreateArticleHandler(IArticleRepository repository) : IRequestHandler<CreateArticleCommand, Guid>
{
    public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.CreateArticle(request.article);
        
        if(request.article.Id == Guid.Empty)
            return Guid.Empty;

        return result;
    }
}