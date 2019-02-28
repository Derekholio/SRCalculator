using System.ComponentModel.DataAnnotations;

namespace SRCalculator.SQLite
{
    public class Player
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public int SR { get; set; }
        [Display(Name = "Private Profile")]
        public bool PrivateProfile { get; set; }
        public string RankImage { get; set; }
    }
}