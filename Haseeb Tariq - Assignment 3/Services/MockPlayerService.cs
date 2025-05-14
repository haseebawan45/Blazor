using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootBall.Models;

namespace FootBall.Services
{
    public class MockPlayerService : IPlayerService
    {
        private List<Player> _players;

        public MockPlayerService()
        {
            // Initialize with some mock data
            _players = new List<Player>
            {
                new Player { Id = 1, Name = "Cristiano Ronaldo", Age = 36, Position = "Forward", Nationality = "Portugal" },
                new Player { Id = 2, Name = "Lionel Messi", Age = 34, Position = "Forward", Nationality = "Argentina" },
                new Player { Id = 3, Name = "Manuel Neuer", Age = 35, Position = "Goalkeeper", Nationality = "Germany" },
                new Player { Id = 4, Name = "Sergio Ramos", Age = 35, Position = "Defender", Nationality = "Spain" },
                new Player { Id = 5, Name = "Kevin De Bruyne", Age = 30, Position = "Midfielder", Nationality = "Belgium" },
                new Player { Id = 6, Name = "Virgil van Dijk", Age = 30, Position = "Defender", Nationality = "Netherlands" },
                new Player { Id = 7, Name = "Kylian Mbappé", Age = 22, Position = "Forward", Nationality = "France" },
                new Player { Id = 8, Name = "N'Golo Kanté", Age = 30, Position = "Midfielder", Nationality = "France" }
            };
        }

        public Task<List<Player>> GetAllPlayersAsync()
        {
            return Task.FromResult(_players);
        }

        public Task<Player> GetPlayerByIdAsync(int id)
        {
            var player = _players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                // Return a default player if none found to avoid null reference
                return Task.FromResult(new Player { Id = 0, Name = "Unknown", Age = 0, Position = "Unknown", Nationality = "Unknown" });
            }
            return Task.FromResult(player);
        }

        public Task<List<Player>> GetPlayersByPositionAsync(string position)
        {
            return Task.FromResult(_players.Where(p => p.Position.Equals(position, System.StringComparison.OrdinalIgnoreCase)).ToList());
        }

        public Task<bool> AddPlayerAsync(Player player)
        {
            player.Id = _players.Max(p => p.Id) + 1;
            _players.Add(player);
            return Task.FromResult(true);
        }

        public Task<bool> UpdatePlayerAsync(Player player)
        {
            var existingPlayer = _players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer == null)
                return Task.FromResult(false);

            existingPlayer.Name = player.Name;
            existingPlayer.Age = player.Age;
            existingPlayer.Position = player.Position;
            existingPlayer.Nationality = player.Nationality;
            
            return Task.FromResult(true);
        }

        public Task<bool> DeletePlayerAsync(int id)
        {
            var player = _players.FirstOrDefault(p => p.Id == id);
            if (player == null)
                return Task.FromResult(false);

            _players.Remove(player);
            return Task.FromResult(true);
        }
    }
} 