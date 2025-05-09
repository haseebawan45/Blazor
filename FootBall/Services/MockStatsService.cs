using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootBall.Models;

namespace FootBall.Services
{
    public class MockStatsService : IStatsService
    {
        private List<Stat> _stats;
        private List<Injury> _injuries;

        public MockStatsService()
        {
            // Initialize with mock stats data
            _stats = new List<Stat>
            {
                // Match performance stats
                new MatchPerformanceStat
                {
                    Id = 1,
                    PlayerId = 1,
                    Date = DateTime.Now.AddDays(-5),
                    MatchId = "M001",
                    Goals = 2,
                    Assists = 1,
                    Passes = 45,
                    PassAccuracy = 0.85,
                    MinutesPlayed = 90
                },
                new MatchPerformanceStat
                {
                    Id = 2,
                    PlayerId = 2,
                    Date = DateTime.Now.AddDays(-5),
                    MatchId = "M001",
                    Goals = 1,
                    Assists = 2,
                    Passes = 52,
                    PassAccuracy = 0.90,
                    MinutesPlayed = 90
                },
                
                // Fitness stats
                new FitnessStat
                {
                    Id = 3,
                    PlayerId = 1,
                    Date = DateTime.Now.AddDays(-5),
                    MatchId = "M001",
                    DistanceRun = 10.5,
                    SprintCount = 22,
                    TopSpeed = 32.1
                },
                new FitnessStat
                {
                    Id = 4,
                    PlayerId = 2,
                    Date = DateTime.Now.AddDays(-5),
                    MatchId = "M001",
                    DistanceRun = 11.2,
                    SprintCount = 18,
                    TopSpeed = 30.8
                }
            };

            // Initialize with mock injury data
            _injuries = new List<Injury>
            {
                new Injury
                {
                    Id = 1,
                    PlayerId = 3,
                    InjuryType = "Hamstring",
                    StartDate = DateTime.Now.AddMonths(-2),
                    EndDate = DateTime.Now.AddMonths(-1),
                    GamesMissed = 4,
                    Description = "Moderate hamstring strain"
                },
                new Injury
                {
                    Id = 2,
                    PlayerId = 6,
                    InjuryType = "ACL",
                    StartDate = DateTime.Now.AddMonths(-8),
                    EndDate = DateTime.Now.AddMonths(-3),
                    GamesMissed = 22,
                    Description = "ACL tear requiring surgery"
                }
            };
        }

        public Task<List<Stat>> GetPlayerStatsAsync(int playerId)
        {
            return Task.FromResult(_stats.Where(s => s.PlayerId == playerId).ToList());
        }

        public Task<List<MatchPerformanceStat>> GetPlayerMatchStatsAsync(int playerId)
        {
            return Task.FromResult(_stats.Where(s => s.PlayerId == playerId && s.Type == StatType.MatchPerformance)
                                        .Cast<MatchPerformanceStat>()
                                        .ToList());
        }

        public Task<List<FitnessStat>> GetPlayerFitnessStatsAsync(int playerId)
        {
            return Task.FromResult(_stats.Where(s => s.PlayerId == playerId && s.Type == StatType.Fitness)
                                        .Cast<FitnessStat>()
                                        .ToList());
        }

        public Task<List<Injury>> GetPlayerInjuriesAsync(int playerId)
        {
            return Task.FromResult(_injuries.Where(i => i.PlayerId == playerId).ToList());
        }

        public Task<bool> AddStatAsync<T>(T stat) where T : Stat
        {
            stat.Id = _stats.Count > 0 ? _stats.Max(s => s.Id) + 1 : 1;
            _stats.Add(stat);
            return Task.FromResult(true);
        }

        public Task<bool> AddInjuryAsync(Injury injury)
        {
            injury.Id = _injuries.Count > 0 ? _injuries.Max(i => i.Id) + 1 : 1;
            _injuries.Add(injury);
            return Task.FromResult(true);
        }
    }
} 