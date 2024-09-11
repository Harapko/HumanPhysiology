using AutoMapper;
using HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;
using HumPsi.Application.CommandQuery.Article.Commands.DeleteArticleCommand;
using HumPsi.Application.CommandQuery.Article.Commands.UpdateArticleCommand;
using HumPsi.Application.CommandQuery.Article.Queries.GetAllArticleQuery;
using HumPsi.Application.CommandQuery.Article.Queries.GetArticleForHeadlineIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HumPsi.Api.Controllers;

[ApiController]
[Route("[action]")]
public class ArticleController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GetArticleDtoResponse>>> GetAllArticlesAsync()
    {
        var result = await mediator.Send(new GetAllArticleQuery());

        if (result.Count == 0)
            return BadRequest("Article not found or null");

        return result;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetArticleDtoResponse>>> GetArticleFromHeadlineIdAsync(Guid headlineId)
    {
        var result = await mediator.Send(new GetArticleFromHeadlineIdQuery(headlineId));

        if (result.Count == 0)
            return BadRequest("Article not found or null");
        
        return result;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateArticleAsync([FromForm] CreateArticleDtoRequest request)
    {
        var result = await mediator.Send(new CreateArticleCommand(request));

        if (result.code == 0)
            return BadRequest(result.text);

        return Ok(new {message = result.text});
    }

    [HttpPut]
    public async Task<ActionResult<string>> UpdateArticleAsync([FromForm] UpdateArticleDtoRequest request)
    {
        var result = await mediator.Send(new UpdateArticleCommand(request));

        if (result.code == 0)
            return BadRequest(result.text);

        return result.text;
    }

    [HttpDelete]
    public async Task<ActionResult<string>> DeleteArticleAsync(Guid id)
    {
        var result = await mediator.Send(new DeleteArticleCommand(id));

        return Ok(new { message = $"Article {result} was delete" });
    }
}