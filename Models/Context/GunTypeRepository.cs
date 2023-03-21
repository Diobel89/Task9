using Task9.Models.Context.Interfaces;

namespace Task9.Models.Context
{
    internal class GunTypeRepository : IGunTypeRepository
    {
        private DatabaseContext context;
        public GunTypeRepository()
        {
            this.context = new DatabaseContext();
        }
        public IEnumerable<GunType> GetAllGunTypes()
        {
            return context.GunTypes.ToList();
        }
        public void AddGunType(GunType gunType)
        {
            context.GunTypes.Add(gunType);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public bool CheckIdExists(int id)
        {
            foreach (var info in context.GunTypes)
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
