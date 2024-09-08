using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;

public record CreateArticleCommand(ArticleEntity article) : IRequest<Guid>;