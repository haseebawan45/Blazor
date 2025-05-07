using System;
using System.ComponentModel.DataAnnotations;

namespace SportsTracking.Models
{
    public abstract class SportActivity
    {
        [Required]
        public string PlayerName { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required]
        [Range(1, 480, ErrorMessage = "Duration must be between 1 and 480 minutes")]
        public int DurationMinutes { get; set; } = 60;

        [Required]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        public int PerformanceRating { get; set; } = 5;

        public string Notes { get; set; } = string.Empty;

        public abstract string SportType { get; }

        public abstract string GetPerformanceMetrics();
    }
} 