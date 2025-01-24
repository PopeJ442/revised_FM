using ElevenEleven.Data;
using ElevenEleven.Models;
using ElevenEleven.Repository.IRepository.IRepository;

namespace ElevenEleven.Repository
{
    public class CoachRepository : BaseRepository<Coach>, ICoachRepository
    {
        public CoachRepository(ApplicationDbContext DbContext) : base(DbContext) 
        {
            
        }
    }
}
