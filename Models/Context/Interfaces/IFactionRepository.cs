using Task9.Models;

namespace Task9.Interfaces
{
    public interface IFactionRepository : IDisposable
    {
            IEnumerable<Faction> GetAllFactions();
            void AddFaction(Faction faction);
            void Save();
    }
}
