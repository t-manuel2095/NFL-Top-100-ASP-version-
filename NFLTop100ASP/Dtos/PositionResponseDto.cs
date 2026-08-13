namespace NFLTop100ASP.Dtos
{
    /*
     * These are small response DTOs for endpoints that don’t return a full player, just a wrapper object. Each class matches one JSON shape: a list of positions, 
     * a list of teams, a total count, or an image’s filename and folder. Keeping them separate avoids stuffing unrelated fields into one response(loose coupling). 
     * In general, when an API returns a simple package like { "count": 10 }, give it its own DTO so the contract stays clear and easy to serialize. Each class matches one 
     * endpoint: one for the list of positions, one for teams, one for the total player count, 
     */
    public class PositionResponseDto
    {   
        public List<string> positions { get; set; } = new(); 
    }

    public class TeamResponseDto
    {
        public List<string?> teams { get; set; } = new();
    }

    public class CountResponseDto
    {
        public int count { get; set; }
    }

    public class Image
    {
        public string filename { get; set; } = "";
        public string folder { get; set; } = "";
    }
}
