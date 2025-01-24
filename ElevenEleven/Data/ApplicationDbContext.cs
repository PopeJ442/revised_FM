using ElevenEleven.Models;
using Microsoft.EntityFrameworkCore;

namespace ElevenEleven.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Coach>Coaches { get; set; }
        public DbSet<Player>Players { get; set; }
        public DbSet<Team>Teams { get; set; }
        public DbSet<Role>Roles { get; set; }
        public DbSet<Specialization>Specializations { get; set; }
        public DbSet<Image> Images { get; set; }
      



    }
}
