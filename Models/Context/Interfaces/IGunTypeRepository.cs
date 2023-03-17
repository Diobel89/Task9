
namespace Task9.Models.Context.Interfaces
{
    public interface IGunTypeRepository : IDisposable
    {
        IEnumerable<GunType> GetAllGunTypes();
        void AddGunType(GunType gunType);
        void Save();
        bool CheckIdExists(int id);
    }
}
