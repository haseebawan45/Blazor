using System.Collections.Generic;
using System.Threading.Tasks;
using FootBall.Models;

namespace FootBall.Services
{
    // Interface for Stats Service - follows OCP by allowing multiple implementations
    public interface IStatsService
    {
        Task<List<Stat>> GetPlayerStatsAsync(int playerId);
        Task<List<MatchPerformanceStat>> GetPlayerMatchStatsAsync(int playerId);
        Task<List<FitnessStat>> GetPlayerFitnessStatsAsync(int playerId);
        Task<List<Injury>> GetPlayerInjuriesAsync(int playerId);
        Task<bool> AddStatAsync<T>(T stat) where T : Stat;
        Task<bool> AddInjuryAsync(Injury injury);
    }
} 