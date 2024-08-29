using AutoMapper;
using HumPsi.Application.Command_Query.Headline.Commands.DeleteHeadlineCommand;
using HumPsi.Application.Headline.Commands.CreateHeadlineCommand;
using HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;
using HumPsi.Application.Headline.Queries;
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
    public async Task<ActionResult<GetHeadlineDtoResponse>> CreateHeadlineAsync([FromForm] CreateHeadlineDto request)
    {
        var result = await mediator.Send(new CreateHeadlineCommand(request.title, request.file, request.sectionId));
        var response = mapper.Map<GetHeadlineDtoResponse>(result);

        if (response.id == Guid.Empty)
            return BadRequest();

        return response;
    }

    [HttpPut]
    public async Task<ActionResult<string>> UpdateHeadlineAsync([FromForm] UpdateHeadlineDtoRequest request)
    {
        var result = await mediator.Send(new UpdateHeadlineCommand(request.id, request.title, request.file));
        
        if (result == Guid.Empty)
            return BadRequest("Update is failure");

        return Ok(new { message = $"Headline was updated on {request.title}" });
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