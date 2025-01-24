using ElevenEleven.Data;
using ElevenEleven.Models;
using ElevenEleven.Repository.IRepository;

namespace ElevenEleven.Repository
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
