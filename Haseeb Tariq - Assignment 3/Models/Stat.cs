using System;

namespace FootBall.Models
{
    // Base Stat class - implements OCP by allowing extension through derived classes
    public abstract class Stat
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime Date { get; set; }
        public required string MatchId { get; set; }
        public StatType Type { get; set; }
    }

    // Enum for categorizing stats
    public enum StatType
    {
        MatchPerformance,
        Fitness,
        Injury
    }

    // Match Performance Stats
    public class MatchPerformanceStat : Stat
    {
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Passes { get; set; }
        public double PassAccuracy { get; set; }
        public int MinutesPlayed { get; set; }

        public MatchPerformanceStat()
        {
            Type = StatType.MatchPerformance;
        }
    }

    // Fitness Stats
    public class FitnessStat : Stat
    {
        public double DistanceRun { get; set; } // in kilometers
        public int SprintCount { get; set; }
        public double TopSpeed { get; set; } // in km/h
        
        public FitnessStat()
        {
            Type = StatType.Fitness;
        }
    }

    // Injury model
    public class Injury
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public required string InjuryType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int GamesMissed { get; set; }
        public required string Description { get; set; }
    }
} 