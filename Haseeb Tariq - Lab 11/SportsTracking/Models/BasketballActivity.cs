using System.ComponentModel.DataAnnotations;

namespace SportsTracking.Models
{
    public class BasketballActivity : SportActivity
    {
        [Range(0, 200, ErrorMessage = "Points must be between 0 and 200")]
        public int PointsScored { get; set; } = 0;

        [Range(0, 100, ErrorMessage = "Rebounds must be between 0 and 100")]
        public int Rebounds { get; set; } = 0;

        public override string SportType => "Basketball";

        public override string GetPerformanceMetrics()
        {
            return $"Points: {PointsScored}, Rebounds: {Rebounds}";
        }
    }
} 