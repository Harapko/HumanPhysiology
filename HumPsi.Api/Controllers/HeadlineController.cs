using HumPsi.Application.Headline.Commands.CreateHeadlineCommand;
using HumPsi.Application.Headline.Queries;
using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HumPsi.Api.Controllers;

[ApiController]
[Route("[action]")]
public class HeadlineController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<HeadlineEntity>>> GetHeadlineAsync()
    {
        var result = await mediator.Send(new GetAllHeadlineQuery());

        if (result.Count == 0)
            return BadRequest("Headline not found or null");

        return result;
    }

    [HttpPost]
    public async Task<ActionResult<HeadlineEntity>> CreateHeadlineAsync([FromForm] CreateHeadlineDto request)
    {
        var result = await mediator.Send(new CreateHeadlineCommand(request.title, request.file, request.sectionId));

        if (result.Id == Guid.Empty)
            return BadRequest();

        return result;
    }
}