using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;

public record CreateArticleCommand(CreateArticleDtoRequest request) : IRequest<(int code, string text)>;