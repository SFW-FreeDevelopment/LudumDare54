using System.Text.Json;
using LudumDare54.API.Requests.Players;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LudumDare54.API.Controllers;

[ApiController]
[Route("game")]
public class HighScoreController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public HighScoreController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("highScores")]
    [SwaggerResponse(StatusCodes.Status200OK, "Get ordered player list by name")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, null)]
    public async Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("highScores/{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Get player resource by id")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, null)]
    [SwaggerResponse(StatusCodes.Status404NotFound, null)]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var result = await _mediator.Send(new GetHighScoreQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }
    
    [HttpGet("highScores/getTopTen")]
    [SwaggerResponse(StatusCodes.Status200OK, "Get the current top 10 players")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, null)]
    public async Task<IActionResult> GetTopTen()
    {
        throw new NotImplementedException();
    }

    [HttpPost("processGameResults")]
    [SwaggerResponse(StatusCodes.Status201Created, "Called when a game has ended, creates player resource to be displayed on leaderboard")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, null)]
    public async Task<IActionResult> ProcessGameResults([FromBody] object request)
    {
        throw new NotImplementedException();
    }
}