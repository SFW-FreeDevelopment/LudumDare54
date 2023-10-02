using System.Text.Json;
using LudumDare54.API.Models.DTO;
using LudumDare54.API.Requests.HighScores;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LudumDare54.API.Controllers;

[ApiController]
[Route("scores")]
public class HighScoreController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public HighScoreController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "All scores, with filters")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, null)]
    public async Task<IActionResult> Get([FromQuery] string name = null) =>
        Ok(await _mediator.Send(new GetHighScoresQuery(name)));

    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "Create a score entry")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, null)]
    public async Task<IActionResult> ProcessGameResults([FromBody] HighScoreModel request)
    {
        var result = await _mediator.Send(new CreateHighScoreCommand(null, request));
        return Created(result.Id, result);
    }
}