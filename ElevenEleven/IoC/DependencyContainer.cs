using ElevenEleven.Data;
using ElevenEleven.Models;
using ElevenEleven.Repository;
using ElevenEleven.Repository.IRepository.IRepository;
using ElevenEleven.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ElevenEleven.IoC
{
    public class DependencyContainer
    {
        public static void AddDatabase( IConfiguration configuration, IServiceCollection services) 
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer
               (configuration.GetConnectionString("DefaultConnection")));

        }
        public static void AllDependencies(IConfiguration configuration, IServiceCollection services) 
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPlayerRepository,PlayerRepository>();
            services.AddScoped<PlayerService>();
            services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddScoped<CoachService>();

        }

    }
}
