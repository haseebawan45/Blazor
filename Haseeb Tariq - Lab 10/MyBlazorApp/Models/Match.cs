using System;

namespace MyBlazorApp.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public string Venue { get; set; } = string.Empty;
        public DateTime ScheduledDateTime { get; set; }
        public MatchStatus Status { get; set; } = MatchStatus.Scheduled;
        public int? Team1Score { get; set; }
        public int? Team1Wickets { get; set; }
        public int? Team1Overs { get; set; }
        public double? Team1Balls { get; set; }
        public int? Team2Score { get; set; }
        public int? Team2Wickets { get; set; }
        public int? Team2Overs { get; set; }
        public double? Team2Balls { get; set; }
        public int? WinningTeamId { get; set; }
        
        // Navigation properties
        public Team? Team1 { get; set; }
        public Team? Team2 { get; set; }
        public Team? WinningTeam { get; set; }
    }
    
    public enum MatchStatus
    {
        Scheduled,
        Live,
        Completed,
        Cancelled,
        Postponed
    }
} 