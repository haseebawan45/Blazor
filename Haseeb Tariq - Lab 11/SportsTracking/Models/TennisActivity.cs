using System.ComponentModel.DataAnnotations;

namespace SportsTracking.Models
{
    public class TennisActivity : SportActivity
    {
        [Range(0, 50, ErrorMessage = "Games won must be between 0 and 50")]
        public int GamesWon { get; set; } = 0;

        [Range(0, 10, ErrorMessage = "Sets won must be between 0 and 10")]
        public int SetsWon { get; set; } = 0;

        public override string SportType => "Tennis";

        public override string GetPerformanceMetrics()
        {
            return $"Games Won: {GamesWon}, Sets Won: {SetsWon}";
        }
    }
} 