using Task9.Models;
using Task9.Models.Context;
using Task9.Models.Context.Interfaces;

namespace Task9.Functions.Simulation
{
    public class Fleet 
    {
        private readonly IGunRepository _gunRepository;
        public Fleet()
        {
            _gunRepository = new GunRepository();
        }
        public List<Fleet> fleet1 = new List<Fleet>();
        public List<Fleet> fleet2 = new List<Fleet>();
        public List<Fleet> graveyard = new List<Fleet>();
        public Ship Ship { get; set; }
        public int ShipTotalDamage { get; set; }
        public int FleetNumber { get; set; }

        public int SetTotalDamage(Ship ship)
        {
            ShipTotalDamage = GetGunTotalDamage(ship.GunId);
            ShipTotalDamage *= ship.Turrets;
            return ShipTotalDamage;
        }
        private int GetGunTotalDamage(int id)
        {
            var gun = _gunRepository.GetGun(id);
            return gun.Damage * gun.Barrels;
        }
        public int GetFleetNumber()
        {
            return FleetNumber; // przemyśleć
        }
    }
}
