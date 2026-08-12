using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public float? Sk {  get; set; }
        public int? Int2 { get; set; }
        public int? Year { get; set; }

        [Key]
        [Column("Id")]
        public int Id { get; set; }


    }
}
