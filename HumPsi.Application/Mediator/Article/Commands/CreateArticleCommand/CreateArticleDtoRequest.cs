using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;

public record CreateArticleDtoRequest(
    string title,
    string content,
    DateTime? createAt,
    IFormFile? file,
    Guid headlineId
    );