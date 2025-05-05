using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlazorApp.Models;

namespace MyBlazorApp.Services
{
    public class CricketDataService
    {
        private List<Team> _teams = new();
        private List<Match> _matches = new();

        public CricketDataService()
        {
            // Initialize with some sample data
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            _teams = new List<Team>
            {
                new Team { Id = 1, Name = "Lahore Qalandars", LogoUrl = "images/lq.png" },
                new Team { Id = 2, Name = "Karachi Kings", LogoUrl = "images/kk.png" },
                new Team { Id = 3, Name = "Islamabad United", LogoUrl = "images/iu.png" },
                new Team { Id = 4, Name = "Quetta Gladiators", LogoUrl = "images/qg.png" },
                new Team { Id = 5, Name = "Peshawar Zalmi", LogoUrl = "images/pz.png" },
                new Team { Id = 6, Name = "Multan Sultans", LogoUrl = "images/ms.png" }
            };

            _matches = new List<Match>
            {
                new Match
                {
                    Id = 1,
                    Team1Id = 1,
                    Team2Id = 2,
                    Venue = "National Stadium, Karachi",
                    ScheduledDateTime = DateTime.Now.AddDays(-2),
                    Status = MatchStatus.Completed,
                    Team1Score = 180,
                    Team1Wickets = 8,
                    Team1Overs = 20,
                    Team1Balls = 0,
                    Team2Score = 183,
                    Team2Wickets = 5,
                    Team2Overs = 19,
                    Team2Balls = 2,
                    WinningTeamId = 2
                },
                new Match
                {
                    Id = 2,
                    Team1Id = 3,
                    Team2Id = 4,
                    Venue = "Gaddafi Stadium, Lahore",
                    ScheduledDateTime = DateTime.Now.AddDays(-1),
                    Status = MatchStatus.Completed,
                    Team1Score = 165,
                    Team1Wickets = 9,
                    Team1Overs = 20,
                    Team1Balls = 0,
                    Team2Score = 140,
                    Team2Wickets = 10,
                    Team2Overs = 18,
                    Team2Balls = 3,
                    WinningTeamId = 3
                },
                new Match
                {
                    Id = 3,
                    Team1Id = 5,
                    Team2Id = 6,
                    Venue = "Rawalpindi Cricket Stadium, Rawalpindi",
                    ScheduledDateTime = DateTime.Now,
                    Status = MatchStatus.Live,
                    Team1Score = 120,
                    Team1Wickets = 5,
                    Team1Overs = 15,
                    Team1Balls = 0
                },
                new Match
                {
                    Id = 4,
                    Team1Id = 1,
                    Team2Id = 3,
                    Venue = "Gaddafi Stadium, Lahore",
                    ScheduledDateTime = DateTime.Now.AddDays(1),
                    Status = MatchStatus.Scheduled
                },
                new Match
                {
                    Id = 5,
                    Team1Id = 2,
                    Team2Id = 4,
                    Venue = "National Stadium, Karachi",
                    ScheduledDateTime = DateTime.Now.AddDays(2),
                    Status = MatchStatus.Scheduled
                }
            };

            // Update team statistics based on completed matches
            UpdateTeamStatistics();
        }

        private void UpdateTeamStatistics()
        {
            // Reset statistics for all teams
            foreach (var team in _teams)
            {
                team.MatchesPlayed = 0;
                team.MatchesWon = 0;
                team.MatchesLost = 0;
                team.MatchesTied = 0;
                team.NetRunRate = 0.0;
            }

            // Calculate statistics from completed matches
            var completedMatches = _matches.Where(m => m.Status == MatchStatus.Completed).ToList();
            
            foreach (var match in completedMatches)
            {
                var team1 = _teams.First(t => t.Id == match.Team1Id);
                var team2 = _teams.First(t => t.Id == match.Team2Id);

                team1.MatchesPlayed++;
                team2.MatchesPlayed++;

                if (match.WinningTeamId.HasValue)
                {
                    if (match.WinningTeamId == team1.Id)
                    {
                        team1.MatchesWon++;
                        team2.MatchesLost++;
                    }
                    else if (match.WinningTeamId == team2.Id)
                    {
                        team2.MatchesWon++;
                        team1.MatchesLost++;
                    }
                }
                else
                {
                    team1.MatchesTied++;
                    team2.MatchesTied++;
                }
                
                // Simplified net run rate calculation - this is just for demonstration
                // In a real application, this would be more complex
                if (match.Team1Score.HasValue && match.Team2Score.HasValue && 
                    match.Team1Overs.HasValue && match.Team2Overs.HasValue)
                {
                    double team1Overs = match.Team1Overs.Value + (match.Team1Balls.HasValue ? match.Team1Balls.Value / 6.0 : 0);
                    double team2Overs = match.Team2Overs.Value + (match.Team2Balls.HasValue ? match.Team2Balls.Value / 6.0 : 0);
                    
                    if (team1Overs > 0 && team2Overs > 0)
                    {
                        double team1RunRate = match.Team1Score.Value / team1Overs;
                        double team2RunRate = match.Team2Score.Value / team2Overs;
                        
                        team1.NetRunRate += (team1RunRate - team2RunRate) / team1.MatchesPlayed;
                        team2.NetRunRate += (team2RunRate - team1RunRate) / team2.MatchesPlayed;
                    }
                }
            }
        }

        // Team-related methods
        public List<Team> GetAllTeams() => _teams.ToList();
        
        public Team GetTeamById(int id) => _teams.FirstOrDefault(t => t.Id == id);

        // Match-related methods
        public List<Match> GetAllMatches() => _matches.ToList();
        
        public List<Match> GetUpcomingMatches() => 
            _matches.Where(m => m.Status == MatchStatus.Scheduled && m.ScheduledDateTime > DateTime.Now)
                   .OrderBy(m => m.ScheduledDateTime)
                   .ToList();
        
        public List<Match> GetPastMatches() => 
            _matches.Where(m => m.Status == MatchStatus.Completed)
                   .OrderByDescending(m => m.ScheduledDateTime)
                   .ToList();
        
        public List<Match> GetLiveMatches() => 
            _matches.Where(m => m.Status == MatchStatus.Live)
                   .ToList();
        
        public Match GetMatchById(int id) => 
            _matches.FirstOrDefault(m => m.Id == id);

        public void AddMatch(Match match)
        {
            match.Id = _matches.Any() ? _matches.Max(m => m.Id) + 1 : 1;
            _matches.Add(match);
        }

        public void UpdateMatch(Match match)
        {
            var existingMatch = _matches.FirstOrDefault(m => m.Id == match.Id);
            if (existingMatch != null)
            {
                int index = _matches.IndexOf(existingMatch);
                _matches[index] = match;
                
                if (match.Status == MatchStatus.Completed)
                {
                    UpdateTeamStatistics();
                }
            }
        }

        // Standings-related methods
        public List<Team> GetStandings() => 
            _teams.OrderByDescending(t => t.Points)
                 .ThenByDescending(t => t.NetRunRate)
                 .ToList();
    }
} 