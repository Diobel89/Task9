namespace Task9.Models.Context.Interfaces
{
    public interface IShipTypeRepository : IDisposable
    {
        IEnumerable<ShipType> GetAllShipTypes();
        void AddShipType(ShipType shipType);
        void Save();
        bool CheckIdExists(int id);
    }
}
