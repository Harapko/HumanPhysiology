using AutoMapper;
using HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;
using HumPsi.Application.CommandQuery.Article.Queries.GetAllArticleQuery;
using HumPsi.Application.CommandQuery.Article.Queries.GetArticleForHeadlineIdQuery;
using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HumPsi.Api.Controllers;

[ApiController]
[Route("[action]")]
public class ArticleController(
    IMediator mediator,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GetArticleDtoResponse>>> GetAllArticlesAsync()
    {
        var result = await mediator.Send(new GetAllArticleQuery());

        var response = mapper.Map<List<GetArticleDtoResponse>>(result);
        if (result.Count == 0)
            return BadRequest("Article not found or null");

        return response;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetArticleDtoResponse>>> GetArticleFromHeadlineIdAsync(Guid headlineId)
    {
        var result = await mediator.Send(new GetArticleFromHeadlineIdQuery(headlineId));

        if (result.Count == 0)
            return BadRequest("Article not found or null");

        var response = mapper.Map<List<GetArticleDtoResponse>>(result);

        return response;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateArticleAsync([FromBody] CreateArticleDtoRequest request)
    {
        var article = mapper.Map<ArticleEntity>(request);

        var result = await mediator.Send(new CreateArticleCommand(article));

        if (result == Guid.Empty)
            return BadRequest("Create Article wrong");

        return result;
    }
}