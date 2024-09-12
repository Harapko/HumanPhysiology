using HumPsi.Domain.Abstraction.IRepositories;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Commands.DeleteArticleCommand;

public class DeleteArticleHandler(IArticleRepository repository) : IRequestHandler<DeleteArticleCommand, string>
{
    public async Task<string> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteArticle(request.id);

        return result;
    }
}