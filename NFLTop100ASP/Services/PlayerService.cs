using Microsoft.EntityFrameworkCore;
using NFLTop100ASP.Data;
using NFLTop100ASP.Dtos;
using NFLTop100ASP.Models;

namespace NFLTop100ASP.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public PlayerService(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        async Task<PlayerDto?> IPlayerService.GetByIdAsync(int id)
        {
            var entity = await _db.players.FindAsync(id);

            if (entity is null)
                return null;

            return ToDto(entity);
        }

        async Task<CountResponseDto> IPlayerService.GetCountAsync()
        {
            var count = await _db.players.CountAsync();

            return new CountResponseDto
            {
                count = count
            };
        }

        async Task<List<PlayerDto>> IPlayerService.GetPlayersAsync(int? year, string? pos, string? tm, string? search)
        {
            var query = _db.players.AsQueryable();

            if (year.HasValue)
                query = query.Where(p => p.Year == year.Value);

            if (!string.IsNullOrWhiteSpace(pos))
                query = query.Where(p => p.Pos == pos);

            if (!string.IsNullOrWhiteSpace(tm))
                query = query.Where(p => p.Tm == tm);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p =>
                    EF.Functions.Like(p.player!, $"%{search}%"));
            }

            var players = await query.ToListAsync();
            return players.Select(ToDto).ToList();
        }

        async Task<PositionResponseDto> IPlayerService.GetPositionsAsync()
        {
            var positions = await _db.players
                .Where(p => p.Pos != null)
                .Select(p => p.Pos)
                .Distinct()
                .ToListAsync();

            return new PositionResponseDto
            {
                positions = positions
            };
        }

        async Task<TeamResponseDto> IPlayerService.GetTeamsAsync()
        {
            var teams = await _db.players
                    .Select(p => p.Tm)
                    .Distinct()
                    .ToListAsync();

            return new TeamResponseDto
            {
                teams = teams
            };
        }

        public Task<Image?> ResolveImageAsync(string player, string year)
        {
            if (string.IsNullOrWhiteSpace(player) || string.IsNullOrWhiteSpace(year))
                return Task.FromResult<Image?>(null);

            var basePath = Path.Combine(_env.WebRootPath, "static", "images");

            var candidates = new[]
            {
                player,
                player.TrimEnd('.'),
                player.Replace(" Jr.", " Jr", StringComparison.Ordinal)
            };

            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            string[] extensions = [".webp", ".jpg", ".jpeg", ".avif", ".png"];

            foreach (var name in candidates)
            {
                if (string.IsNullOrWhiteSpace(name) || !seen.Add(name))
                    continue;

                var imagesDir = Path.Combine(basePath, name, year);

                if (!Directory.Exists(imagesDir))
                    continue;

                var file = Directory.EnumerateFiles(imagesDir)
                    .Select(Path.GetFileName)
                    .FirstOrDefault(f =>
                        f != null &&
                        extensions.Contains(Path.GetExtension(f), StringComparer.OrdinalIgnoreCase));

                if (file != null)
                {
                    return Task.FromResult<Image?>(new Image
                    {
                        filename = file,
                        folder = name
                    });
                }
            }
            return Task.FromResult<Image?>(null);
        }
        private static PlayerDto ToDto(Player p)
        {
            return new PlayerDto
            {
                Id = p.Id,
                rank = p.Rank,
                pos = p.Pos,
                player = p.player,       
                tm = p.Tm,
                g = p.G,
                gs = p.GS,
                cmp = p.Cmp,
                att = p.Att,
                yds = p.Yds,
                td = p.TD,               
                passing_int = p.Int,     // entity Int → DTO passing_int
                att2 = p.Att2,
                yds2 = p.Yds2,
                td2 = p.TD2,            
                rec = p.Rec,
                yds3 = p.Yds3,
                td3 = p.TD3,
                solo = p.Solo,
                sk = p.Sk,
                int2 = p.Int2,
                year = p.Year
            };
        }
    }
}
