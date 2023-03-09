using Microsoft.EntityFrameworkCore;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.View.Interface;

namespace Task9.View
{
    public class ShipDisplay : IShipDisplay
    {
        private readonly IOutput output;
        public ShipDisplay(IOutput output)
        {
            this.output = output;
        }
        public void DisplayAll(List<Ship> shipList)
        {
            foreach (Ship ship in shipList)
            {
                Display(ship);
            }
        }
        private void Display(Ship ship)
        {
            string factionName = GetFactionName(ship.FactionId);
            string gunName = GetGunName(ship.GunId);
            var info = string.Join(" ", "ID: [" + ship.Id
                + "]" + " Name: [" + ship.Name
                + "]" + " Turrets: [" + ship.Turrets
                + "]" + " Gun: [" + gunName
                + "]" + " Armor: [" + ship.Armor
                + "]" + " HP: [" + ship.HP
                + "]" + " Faction: [" + factionName
                + "]"); ;
            output.ShowMessage(info);
        }
        private string GetFactionName(int id)
        {
            using (var db = new DatabaseContext())
            {
                foreach (var info in db.Factions)
                {
                    if (info.Id == id)
                    {
                        return info.Name;
                    }
                }
            }
            return string.Empty;
        }
        private string GetGunName(int id)
        {
            using (var db = new DatabaseContext())
            {
                foreach (var info in db.Guns)
                {
                    if (info.Id == id)
                    {
                        return info.Name;
                    }
                }
            }
            return string.Empty;
        }
    }
}
