using AutoMapper;
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
    public async Task<ActionResult<List<GetSectionDtoResponse>>> GetAllSectionAsync()
    {
        var result = await mediator.Send(new GetAllSectionQuery());

        if (result.Count == 0)
            return NotFound("Section not found or null");

        return result;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateSectionAsync([FromBody] CreateSectionDtoRequest request)
    {
        var result = await mediator.Send(new CreateSectionCommand(request));

        if (result.code == 0)
            return BadRequest(result.text);

        return Ok(new {message = result.text});
    }

    [HttpPut]
    public async Task<ActionResult<string>> UpdateSectionAsync([FromBody] UpdateSectionDtoRequest request)
    {
        var result = await mediator.Send(new UpdateSectionCommand(request));
        
        if (result.code == 0)
            return BadRequest(result.text);
        
        return Ok(new { message = result.text});
    }

    [HttpDelete]
    public async Task<ActionResult<string>> DeleteSectionAsync([FromBody] Guid id)
    {
        var result = await mediator.Send(new DeleteSectionCommand(id));
        
        if (result == Guid.Empty)
            return BadRequest("Delete is failure");
        
        return Ok(new { message = $"Section {id} was deleted" });
    }
}