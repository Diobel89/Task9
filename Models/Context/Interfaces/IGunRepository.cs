using Task9.Models;

namespace Task9.Interfaces
{
    public interface IGunRepository : IDisposable
    {
        IEnumerable<Gun> GetAllGuns();
        void AddGun(Gun gun);
        void DeleteGun(int gunId);
        void UpdateGun(Gun gun);
        void Save();
    }
}
