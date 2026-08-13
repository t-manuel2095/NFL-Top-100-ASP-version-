using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFLTop100ASP.Dtos;
using NFLTop100ASP.Services;

/*
 * This is an API controller: it defines HTTP endpoints and turns web requests into calls to your app logic. The constructor injects IPlayerService 
 * so the controller doesn’t create the service itself, ASP.NET Core provides it (dependency injection). The [HttpGet] action handles GET /api/players, 
 * reads optional filter values from the query string (year, pos, tm, search), asks the service for data, and returns 200 OK with JSON. In general, 
 * controllers stay thin: route + parameters + call a service + return a result; business rules and database work live in the service.
 */

namespace NFLTop100ASP.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _players; 
        public PlayersController(IPlayerService players)
        {
            _players = players;
        }

        //`GET /api/players/`
        [HttpGet]
        public async Task<ActionResult<List<PlayerDto>>> GetPlayers([FromQuery] int? year, [FromQuery] string? pos,
                                                                    [FromQuery] string? tm, [FromQuery] string? search)
        {
            var result = await _players.GetPlayersAsync(year, pos, tm, search);
            return Ok(result);
        }

        //`GET /api/players/positions/`
        [HttpGet("positions")]
        public async Task<ActionResult<PositionResponseDto>> GetPositions()
        {
            var result = await _players.GetPositionsAsync();
            return Ok(result);
        }

        //`GET /api/players/teams/`
        [HttpGet("teams")]

        public async Task<ActionResult<TeamResponseDto>> GetTeams()
        {
            var result = await _players.GetTeamsAsync();
            return Ok(result);
        }

        //`GET /api/players/count/`
        [HttpGet("count")]

        public async Task<ActionResult<CountResponseDto>> GetCount()
        {
            var result = await _players.GetCountAsync();
            return Ok(result);
        }

        //`GET /api/players/image/?player=&year=`
        [HttpGet("image")]

        public async Task <ActionResult<Image>> GetImage([FromQuery] string player, [FromQuery] string year)
        {
            // image
            if (string.IsNullOrWhiteSpace(player) || string.IsNullOrWhiteSpace(year))
                return BadRequest(new { error = "player and year parameters required" });

            var result = await _players.ResolveImageAsync(player, year);

            if (result is null) return NotFound(new { error = "Image not found" });

            return Ok(result);
        }

        //`GET /api/players/{id}`
        [HttpGet("{id:int}")]

        public async Task <ActionResult<PlayerDto?>> GetPlayerID(int id)
        {
            var result = await _players.GetByIdAsync(id);

            if (result is null) return NotFound();

            return Ok(result);
        }
    }
}
