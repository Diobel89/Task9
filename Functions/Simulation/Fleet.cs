using Task9.Models;
using Task9.Models.Context;

namespace Task9.Functions.Simulation
{
    public class Fleet 
    {
        public List<Fleet> fleet1 = new List<Fleet>();
        public List<Fleet> fleet2 = new List<Fleet>();
        public List<Fleet> graveyard = new List<Fleet>();
        public Ship Ship { get; set; }
        public int ShipTotalDamage { get; set; }
        public int FleetNumber { get; set; }

        public int SetTotalDamage(int id)
        {

            // pobrać DMG broni x liczba luf x liczba wież = total damage
            using (var db = new DatabaseContext())
            {
                foreach (var info in db.Ships)
                {
                    if (info.Id == id)
                    {
                        ShipTotalDamage = GetGunTotalDamage(info.GunId);
                        ShipTotalDamage *= info.Turrets;
                    }
                }
            }
            return ShipTotalDamage;
        }
        private int GetGunTotalDamage(int id)
        {
            //using (var db = new DatabaseContext())
            //{
            //    foreach (var info in db.Guns)
            //    {
            var gun = new GunRepository().GetGun(id);
            return gun.Damage * gun.Barrels;

                //}
            //}
            //return 0;
        }
        public int GetFleetNumber()
        {
            return FleetNumber; // przemyśleć
        }
    }
}
