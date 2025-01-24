
using ElevenEleven.Data;
using ElevenEleven.Models;
using ElevenEleven.Repository.IRepository.IRepository;

namespace ElevenEleven.Repository
{
    public class PlayerRepository: BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
