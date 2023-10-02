using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LudumDare54.API.Controllers;

[ApiController]
[Route("game")]
public class GameController
{
    [HttpGet("players")]
    [SwaggerResponse(StatusCodes.Status200OK, "Get ordered player list by name")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, null)]
    public async Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("players/{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Get player resource by id")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, null)]
    [SwaggerResponse(StatusCodes.Status404NotFound, null)]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("players/getTopTen")]
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