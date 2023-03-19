using Microsoft.EntityFrameworkCore;
using Task9.Models.Context.Interfaces;

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
        public int GetMaxId()
        {
            return context.Factions.Count();
        }
        public bool CheckIdExists(int id)
        {
            foreach (var info in context.Factions)
            {
                if (info.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        public string GetIcon(int factionId)
        {
            foreach (var info in context.Factions)
            {
                if (info.Id == factionId)
                {
                    return info.Icon;
                }
            }
            return "";
        }
        public string GetName(int factionId)
        {
            var info = context.Factions.FirstOrDefault(id => id.Id == factionId);
            return info.Name;
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
