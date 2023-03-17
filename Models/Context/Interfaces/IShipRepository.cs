using Task9.Models;

namespace Task9.Models.Context.Interfaces
{
    public interface IShipRepository : IDisposable
    {
        IEnumerable<Ship> GetAllShips();
        void AddShip(Ship ship);
        void DeleteShip(int ShipId);
        void UpdateShip(Ship ship);
        void Save();
        bool CheckIdExists(int id);
    }
}
