using AutoMapper;
using HumPsi.Application.Command_Query.Headline.Commands.DeleteHeadlineCommand;
using HumPsi.Application.Headline.Commands.CreateHeadlineCommand;
using HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;
using HumPsi.Application.Headline.Queries;
using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HumPsi.Api.Controllers;

[ApiController]
[Route("[action]")]
public class HeadlineController(IMediator mediator,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GetHeadlineDtoResponse>>> GetHeadlineAsync()
    {
        var result = await mediator.Send(new GetAllHeadlineQuery());
        var response = mapper.Map<List<GetHeadlineDtoResponse>>(result);

        if (result.Count == 0)
            return BadRequest("Headline not found or null");

        return response;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateHeadlineAsync([FromForm] CreateHeadlineDtoRequest request)
    {
        var headline = mapper.Map<HeadlineEntity>(request);
        
        var result = await mediator.Send(new CreateHeadlineCommand(request.file, headline));

        if (result.code == 0)
            return BadRequest(result.text);

        return Ok(new { massange = result.text});
    }

    [HttpPut]
    public async Task<ActionResult<string>> UpdateHeadlineAsync([FromForm] UpdateHeadlineDtoRequest request)
    {
        var headline = mapper.Map<HeadlineEntity>(request);
        
        var result = await mediator.Send(new UpdateHeadlineCommand(headline, request.file));
        
        if (result.code == 0)
            return BadRequest(result.text);

        return Ok(new { message = result.text});
    }

    [HttpDelete]
    public async Task<ActionResult<string>> DeleteHeadlineAsync([FromForm] Guid id)
    {
        var result = await mediator.Send(new DeleteHeadlineCommand(id));

        if (result == Guid.Empty)
            return BadRequest("Delete is failure");

        return Ok(new { message = $"Headline {id} was delete" });
    }
}