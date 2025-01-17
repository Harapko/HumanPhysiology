using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Commands.UpdateArticleCommand;

public record UpdateArticleCommand(UpdateArticleDtoRequest request) : IRequest<(int code, string text)>;