using Microsoft.EntityFrameworkCore;
using Task9.Models.Context.Interfaces;

namespace Task9.Models.Context
{
    public class GunRepository : IGunRepository, IDisposable
    {
        private DatabaseContext context;
        public GunRepository()
        {
            this.context = new DatabaseContext();
        }
        public IEnumerable<Gun> GetAllGuns()
        {
            return context.Guns.ToList();
        }
        public void AddGun(Gun gun)
        {
            context.Guns.Add(gun);
        }
        public void DeleteGun(int gunId)
        {
            Gun gun = context.Guns.Find(gunId);
            context.Guns.Remove(gun);
        }
        public void UpdateGun(Gun gun)
        {
            context.Entry(gun).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public int GetMaxId()
        {
                return context.Guns.Count();
        }
        public Gun GetGun(int id)
        {
            Gun gun = context.Guns.FirstOrDefault(i => i.Id == id);
            return gun;
        }
        public string GetName(int gunId)
        {
            Gun gun = context.Guns.FirstOrDefault(id => id.Id == gunId);
            return gun.Name;
        }
        public bool CheckIdExists(int id)
        {
            foreach (var info in context.Guns)
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
