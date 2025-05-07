using System;
using System.Collections.Generic;

namespace SportsTracking.Models
{
    public static class SportActivityFactory
    {
        public static SportActivity CreateSportActivity(string sportType)
        {
            return sportType switch
            {
                "Football" => new FootballActivity(),
                "Basketball" => new BasketballActivity(),
                "Tennis" => new TennisActivity(),
                _ => throw new ArgumentException($"Unknown sport type: {sportType}")
            };
        }

        public static List<string> GetAvailableSportTypes()
        {
            return new List<string> { "Football", "Basketball", "Tennis" };
        }
    }
} 