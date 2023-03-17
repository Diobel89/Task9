using Task9.Models.Context.Interfaces;

namespace Task9.Models.Context
{
    public class ShipTypeRepository : IShipTypeRepository
    {
        private DatabaseContext context;
        public ShipTypeRepository()
        {
            this.context = new DatabaseContext();
        }
        public IEnumerable<ShipType> GetAllShipTypes()
        {
            return context.ShipTypes.ToList();
        }
        public void AddShipType(ShipType shipType)
        {
            context.ShipTypes.Add(shipType);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public bool CheckIdExists(int id)
        {
            foreach (var info in context.ShipTypes)
            {
                if (info.Id == id)
                {
                    return true;
                }
            }
            return false;
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
