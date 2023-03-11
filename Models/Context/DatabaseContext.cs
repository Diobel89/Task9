using Microsoft.EntityFrameworkCore;

namespace Task9.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Gun> Guns { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public string DbPath { get; }
        public DatabaseContext() : base()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "simulation.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
