/*
 * This is a DTO (Data Transfer Object): a plain object that defines the JSON shape your API sends to the browser. Its property names match what the 
 * frontend already expects (player, passing_int, sk, and so on), which can differ from database column names on the entity. It has no EF table/column 
 * attributes, those stay on the model. In general, use DTOs as the public API contract and map from entities into them so the database schema can change 
 * without breaking clients.
 */

namespace NFLTop100ASP.Dtos
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public int rank { get; set; }
        public string pos { get; set; }
        public string player {  get; set; }
        public string? tm { get; set; }
        public int? g {  get; set; }
        public int? gs { get; set; }
        public int? cmp { get; set; }
        public int? att { get; set; }
        public int? yds { get; set; }
        public int? td { get; set; }
        public int? passing_int { get; set; }
        public int? att2 { get; set; }
        public int? yds2 { get; set; }
        public int? td2 { get; set; }
        public int? rec { get; set; }
        public int? yds3 { get; set; }
        public int? td3 { get; set; }
        public int? solo {  get; set; }
        public int? int2 { get; set; }
        public double? sk { get; set; }
        public short? year { get; set; }

    }
}
