using HumPsi.Application.Command_Query.Headline.Commands.DeleteHeadlineCommand;
using HumPsi.Application.CommandQuery.Headline.Queries.GetHeadlineFromSectionIdQuery;
using HumPsi.Application.Headline.Commands.CreateHeadlineCommand;
using HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;
using HumPsi.Application.Headline.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HumPsi.Api.Controllers;

[ApiController]
[Route("[action]")]
public class HeadlineController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GetHeadlineDtoResponse>>> GetHeadlineAsync()
    {
        var result = await mediator.Send(new GetAllHeadlineQuery());

        if (result.Count == 0)
            return BadRequest("Headline not found or null");

        return result;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetHeadlineDtoResponse>>> GetHeadlineFromSectionIdAsync(Guid sectionId)
    {
        var result = await mediator.Send(new GetHeadlineFromSectionIdQuery(sectionId));

        if (result.Count == 0)
            return BadRequest("Headline not found or null");

        return result;
    }
        

    [HttpPost]
    public async Task<ActionResult<string>> CreateHeadlineAsync([FromForm] CreateHeadlineDtoRequest request)
    {
        var result = await mediator.Send(new CreateHeadlineCommand(request.file, request));

        if (result.code == 0)
            return BadRequest(result.text);

        return Ok(new { message = result.text});
    }

    [HttpPut]
    public async Task<ActionResult<string>> UpdateHeadlineAsync([FromForm] UpdateHeadlineDtoRequest request)
    {
        var result = await mediator.Send(new UpdateHeadlineCommand(request, request.file));
        
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