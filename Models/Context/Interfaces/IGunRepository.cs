using Task9.Models;

namespace Task9.Models.Context.Interfaces
{
    public interface IGunRepository : IDisposable
    {
        IEnumerable<Gun> GetAllGuns();
        void AddGun(Gun gun);
        void DeleteGun(int gunId);
        void UpdateGun(Gun gun);
        void Save();
        int GetMaxId();
        Gun GetGun(int id);
        string GetName(int gunId);
        bool CheckIdExists(int id);
    }
}
