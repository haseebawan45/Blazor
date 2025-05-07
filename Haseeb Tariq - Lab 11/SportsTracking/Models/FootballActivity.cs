using System.ComponentModel.DataAnnotations;

namespace SportsTracking.Models
{
    public class FootballActivity : SportActivity
    {
        [Range(0, 100, ErrorMessage = "Goals must be between 0 and 100")]
        public int GoalsScored { get; set; } = 0;

        [Range(0, 100, ErrorMessage = "Assists must be between 0 and 100")]
        public int Assists { get; set; } = 0;

        public override string SportType => "Football";

        public override string GetPerformanceMetrics()
        {
            return $"Goals: {GoalsScored}, Assists: {Assists}";
        }
    }
} 