namespace HumPsi.Application.CommandQuery.Article.Queries.GetAllArticleQuery;

public record GetArticleDtoResponse(
    Guid id,
    string title,
    string content,
    DateTime createAt
);