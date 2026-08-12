namespace NFLTop100ASP.Dtos
{
    /*
     * Each class matches one endpoint: one for the list of positions, one for teams, one for the total player count, 
     * and one for an image’s filename and folder. They don’t talk to the database or handle web requests themselves—they 
     * only describe the shape of the data. Later, your service will fill them in and your controller will return them.
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
