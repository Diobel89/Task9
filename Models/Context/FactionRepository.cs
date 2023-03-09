using Task9.Interfaces;

namespace Task9.Models.Context
{
    public class FactionRepository : IFactionRepository, IDisposable
    {
        private DatabaseContext context;
        public FactionRepository()
        {
            this.context = new DatabaseContext();
        }
        public IEnumerable<Faction> GetAllFactions()
        {
            return context.Factions.ToList();
        }
        public void AddFaction(Faction faction)
        {
            context.Factions.Add(faction);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
