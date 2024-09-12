using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Commands.DeleteArticleCommand;

public record DeleteArticleCommand(Guid id) : IRequest<string>;