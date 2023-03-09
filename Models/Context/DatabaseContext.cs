using Microsoft.EntityFrameworkCore;

namespace Task9.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {

        }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Gun> Guns { get; set; }
        public DbSet<Faction> Factions { get; set; }

    }
}
