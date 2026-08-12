using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFLTop100ASP.Services;

namespace NFLTop100ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _players; 
        public PlayersController(IPlayerService players)
        {
            _players = players;
        }


    }
}
