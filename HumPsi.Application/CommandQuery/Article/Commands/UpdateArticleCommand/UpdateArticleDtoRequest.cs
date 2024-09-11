using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.CommandQuery.Article.Commands.UpdateArticleCommand;

public record UpdateArticleDtoRequest(
    Guid id,
    string title,
    string content,
    DateTime? createAt,
    IFormFile? file,
    Guid headlineId
    );