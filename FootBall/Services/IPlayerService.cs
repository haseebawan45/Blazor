using System.Collections.Generic;
using System.Threading.Tasks;
using FootBall.Models;

namespace FootBall.Services
{
    // Interface for the Player Service - follows OCP by allowing multiple implementations
    public interface IPlayerService
    {
        Task<List<Player>> GetAllPlayersAsync();
        Task<Player> GetPlayerByIdAsync(int id);
        Task<List<Player>> GetPlayersByPositionAsync(string position);
        Task<bool> AddPlayerAsync(Player player);
        Task<bool> UpdatePlayerAsync(Player player);
        Task<bool> DeletePlayerAsync(int id);
    }
} 