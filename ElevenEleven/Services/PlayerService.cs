using ElevenEleven.Models;
using ElevenEleven.Repository;
using ElevenEleven.Repository.IRepository.IRepository;

namespace ElevenEleven.Services
{
    public class PlayerService
    {
        
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository _playerRepository)
        {
            playerRepository = _playerRepository;
        }

          public void AddPlayer(Player player)
        {
            playerRepository.Insert(player);
            playerRepository.Save();
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return playerRepository.GetAll();
        }

        public Player GetPlayerById(int id)
        {
            return playerRepository.GetById(id);
        }

        public void UpdatePlayer(Player player)
        {
            playerRepository.Update(player);
            playerRepository.Save();
        }

        public void DeletePlayer(int id)
        {
            var player = playerRepository.GetById(id);
            if (player != null)
            {
                playerRepository.Delete(player);
                playerRepository.Save();
            }
        }

    }
}