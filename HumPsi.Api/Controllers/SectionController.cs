using HumPsi.Application.Section.Commands.CreateSectionCommand;
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
    public async Task<ActionResult<List<SectionEntity>>> GetAllSection()
    {
        var result = await mediator.Send(new GetAllSectionQuery());
        
        if (result.Count == 0)
            return NotFound("Section not found or null");
        
        return result;
    }

    [HttpPut]
    public async Task<ActionResult<SectionEntity>> CreateSection([FromBody] CreateSectionCommand command)
    {
        var result = await mediator.Send(new CreateSectionCommand(command.Title));

        return result;
    }
}