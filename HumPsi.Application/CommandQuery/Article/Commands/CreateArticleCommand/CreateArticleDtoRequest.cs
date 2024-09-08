namespace HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;

public record CreateArticleDtoRequest(
    Guid id,
    string title,
    string content,
    DateTime createAt,
    Guid headlineId
    );