using Microsoft.EntityFrameworkCore;
using Task9.Models.Context.Interfaces;

namespace Task9.Models.Context
{
    public class ShipRepository : IShipRepository, IDisposable
    {
        private DatabaseContext context;
        public ShipRepository()
        {
            this.context = new DatabaseContext();
        }
        public IEnumerable<Ship> GetAllShips()
        {
            return context.Ships.ToList();
        }
        public void AddShip(Ship ship)
        {
            context.Ships.Add(ship);
        }
        public void DeleteShip(int shipId)
        {
            Ship ship = context.Ships.Find(shipId);
            context.Ships.Remove(ship);
        }
        public void UpdateShip(Ship ship)
        {
            context.Entry(ship).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public int GetMaxId()
        {
            return context.Ships.Count();
        }
        public bool CheckIdExists(int id)
        {
                foreach (var info in context.Ships)
                {
                    if (info.Id == id)
                    {
                        return true;
                    }
                }
                return false;
        }
        public Ship GetShip(int id)
        {
            return context.Ships.FirstOrDefault(i => i.Id == id);
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
