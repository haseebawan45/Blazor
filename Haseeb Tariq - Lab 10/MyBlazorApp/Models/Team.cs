namespace MyBlazorApp.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public int MatchesPlayed { get; set; } = 0;
        public int MatchesWon { get; set; } = 0;
        public int MatchesLost { get; set; } = 0;
        public int MatchesTied { get; set; } = 0;
        public int Points => MatchesWon * 2 + MatchesTied;
        public double NetRunRate { get; set; } = 0.0;
    }
} 