using ConsoleTables;
using System.Numerics;
using Task9.Functions.Simulation;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;
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
        public void GetList()
        {
            var shipList = new ShipRepository().GetAllShips();
            //DisplayAll((List<Ship>)shipList);
            DisplayInTable((List<Ship>)shipList);
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
            int totalDamage = new Fleet().SetTotalDamage(ship);
            var info = string.Join(" ", "ID: [" + ship.Id
                + "]" + " Name: [" + ship.Name
                + "]" + " Turrets: [" + ship.Turrets
                + "]" + " Gun: [" + gunName
                + "]" + " Armor: [" + ship.Armor
                + "]" + " HP: [" + ship.HP
                + "]" + " Faction: [" + factionName
                + "]" + " Damage: [" + totalDamage
                + "]"); 
            output.ShowMessage(info);

        }
        private void DisplayInTable(List<Ship> shipList)
        {
            string factionName;
            string gunName;
            int totalDamage;
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "ID", "ShipName", "Main Gun", "Turrets", "Armor", "HP", "Faction", "Total Damage" },
                EnableCount = false
            });
                foreach(var info in shipList)
                {
                    factionName = GetFactionName(info.FactionId);
                    gunName = GetGunName(info.GunId);
                    totalDamage = new Fleet().SetTotalDamage(info);
                    table.AddRow(info.Id, info.Name, gunName, info.Turrets , info.Armor, info.HP, factionName, totalDamage);
                }
                table.Write();
        }
        private string GetFactionName(int id) // koniecznie zmienić DatabaseContext na FactionRepository!
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
        private string GetGunName(int id) // koniecznie zmienić DatabaseContext na GunRepository!
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
