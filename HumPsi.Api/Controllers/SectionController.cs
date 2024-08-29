using AutoMapper;
using HumPsi.Application.Section.Commands.CreateSectionCommand;
using HumPsi.Application.Section.Commands.DeleteSectionCommand;
using HumPsi.Application.Section.Commands.UpdateSectionCommand;
using HumPsi.Application.Section.Queries.GetAllSectionQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HumPsi.Api.Controllers;

[ApiController]
[Route("[action]")]
public class SectionController(IMediator mediator,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GetSectionDtoResponse>>> GetAllSectionAsync()
    {
        var result = await mediator.Send(new GetAllSectionQuery());
        var response = mapper.Map<List<GetSectionDtoResponse>>(result);

        if (response.Count == 0)
            return NotFound("Section not found or null");

        return response;
    }

    [HttpPost]
    public async Task<ActionResult<GetSectionDtoResponse>> CreateSectionAsync([FromBody] string title)
    {
        var result = await mediator.Send(new CreateSectionCommand(title));
        var response = mapper.Map<GetSectionDtoResponse>(result);

        return response;
    }

    [HttpPut]
    public async Task<ActionResult<string>> UpdateSectionAsync([FromBody] UpdateSectionDtoRequest request)
    {
        var result = await mediator.Send(new UpdateSectionCommand(request.id, request.sectionName));
        
        if (result == Guid.Empty)
            return BadRequest("Update is failure");
        
        return Ok(new { message = $"Section {request.id} was updated on {request.sectionName}" });
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