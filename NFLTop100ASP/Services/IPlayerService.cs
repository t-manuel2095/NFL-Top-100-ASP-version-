using NFLTop100ASP.Dtos;

/*
 * IPlayerService is a promise of what the player “business logic” layer can do. It doesn’t run any 
 * database code itself it only lists the operations (get players with filters, get one by id, positions,
 * teams, count, resolve an image) and what they return.
 */

namespace NFLTop100ASP.Services
{
    public interface IPlayerService
    {
        Task<List<PlayerDto>> GetPlayersAsync(int? year, string? pos, string? tm, string? search);
        Task<PlayerDto?> GetByIdAsync(int id);
        Task<PositionResponseDto> GetPositionsAsync();
        Task<TeamResponseDto> GetTeamsAsync();
        Task<CountResponseDto> GetCountAsync();
        Task<Image?> ResolveImageAsync(string player, string year);
    }
}
