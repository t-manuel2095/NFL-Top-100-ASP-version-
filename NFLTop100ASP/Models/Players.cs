using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 * This is an entity model: a C# class that maps to one database table so EF Core can read rows as objects. [Table("User")] and [Column] / [Key] 
 * tell EF which table and columns to use when C# names differ from SQL. Property types must match the real SQL types (double for SQL float, 
 * short for smallint, and so on). In general, the entity mirrors storage. You map it to a DTO before sending JSON to the client.
 */

namespace NFLTop100ASP.Models
{
    [Table("User")]
    public class Player
    {
        public int Rank { get; set; }
        public string Pos { get; set; }

        [Column("Player")]
        public string player { get; set; }
        public string? Tm { get; set; }
        public int? G {  get; set; }
        public int? GS { get; set; }
        public int? Cmp { get; set; }
        public int? Att { get; set; }
        public int? Yds { get; set; }
        public int? TD { get; set; }
        public int? Int { get; set; }
        public int? Att2 { get; set; }
        public int? Yds2 { get; set; }
        public int? TD2 { get; set; }
        public int? Rec { get; set; }
        public int? Yds3 { get; set; }
        public int? TD3 { get; set; }
        public int? Solo { get; set; }
        public double? Sk {  get; set; }
        public int? Int2 { get; set; }
        public short? Year { get; set; }

        [Key]
        [Column("Id")]
        public int Id { get; set; }


    }
}
