using ElevenEleven.Data;
using ElevenEleven.Models;
using ElevenEleven.Repository;
using ElevenEleven.Repository.IRepository.IRepository;

namespace ElevenEleven.Services
{
    public class CoachService 
    {
        private readonly ICoachRepository coachRepository;
        public CoachService(ICoachRepository _coachRepository)
        {
            coachRepository = _coachRepository;
        }


        public void AddCoach(Coach coach)
        {
            coachRepository.Insert(coach);
            coachRepository.Save();
        }

        public IEnumerable<Coach> GetAllCoaches()
        {
            return coachRepository.GetAll();
        }

        public Coach GetCoachById(int id)
        {
            return coachRepository.GetById(id);
        }

        public void UpdateCoach(Coach Coach)
        {
            coachRepository.Update(Coach);
            coachRepository.Save();
        }

        public void DeleteCoach(int id)
        {
            var Coach = coachRepository.GetById(id);
            if (Coach != null)
            {
                coachRepository.Delete(Coach);
                coachRepository.Save();
            }
        }
    }
}
