using Task9.Models;

namespace Task9.Models.Context.Interfaces
{
    public interface IFactionRepository : IDisposable
    {
        IEnumerable<Faction> GetAllFactions();
        void AddFaction(Faction faction);
        void Save();
        bool CheckIdExists(int id);
    }
}
