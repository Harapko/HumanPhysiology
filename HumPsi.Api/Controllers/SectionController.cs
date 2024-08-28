using HumPsi.Application.Section.Commands.CreateSectionCommand;
using HumPsi.Application.Section.Commands.DeleteSectionCommand;
using HumPsi.Application.Section.Commands.UpdateSectionCommand;
using HumPsi.Application.Section.Queries.GetAllSectionQuery;
using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HumPsi.Api.Controllers;

[ApiController]
[Route("[action]")]
public class SectionController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<SectionEntity>>> GetAllSectionAsync()
    {
        var result = await mediator.Send(new GetAllSectionQuery());

        if (result.Count == 0)
            return NotFound("Section not found or null");

        return result;
    }

    [HttpPost]
    public async Task<ActionResult<SectionEntity>> CreateSectionAsync([FromBody] CreateSectionCommand command)
    {
        var result = await mediator.Send(new CreateSectionCommand(command.Title));

        return result;
    }

    [HttpPut]
    public async Task<ActionResult<string>> UpdateSectionAsync([FromBody] UpdateSectionCommand command)
    {
        var result = await mediator.Send(new UpdateSectionCommand(command.Id, command.SectionName));
        
        if (result == Guid.Empty)
            return BadRequest("Update is failure");
        
        return Ok(new { message = $"Section {command.Id} was updated on {command.SectionName}" });
    }

    [HttpDelete]
    public async Task<ActionResult<Guid>> DeleteSectionAsync([FromBody] DeleteSectionCommand command)
    {
        var result = await mediator.Send(new DeleteSectionCommand(command.Id));
        
        if (result == Guid.Empty)
            return BadRequest("Update is failure");
        
        return Ok(new { message = $"Section {command.Id} was deleted" });
    }
}