using ElevenEleven.Data;
using ElevenEleven.Models;
using ElevenEleven.Repository;
using ElevenEleven.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ElevenEleven.Services
{
    public class TeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository _iteamRepository)
        {
            teamRepository = _iteamRepository;

        }
        public void AddTeam(Team team)
        {
            teamRepository.Insert(team);
            teamRepository.Save();
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return teamRepository.GetAll();
        }

        public Team GetTeamById(int id)
        {
            return teamRepository.GetById(id);
        }

        public void UpdateTeam(Team team)
        {
            teamRepository.Update(team);
            teamRepository.Save();
        }

        public void DeleteCoach(int id)
        {
            var Team = teamRepository.GetById(id);
            if (Team != null)
            {
                teamRepository.Delete(Team);
                teamRepository.Save();
            }
        }
    }
}
