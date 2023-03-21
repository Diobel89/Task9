namespace Task9.Models.Context.Interfaces
{
    public interface IFactionRepository : IDisposable
    {
        IEnumerable<Faction> GetAllFactions();
        void AddFaction(Faction faction);
        void Save();
        int GetMaxId();
        bool CheckIdExists(int id);
        string GetIcon(int factionId);
        string GetName(int factionId);
    }
}
