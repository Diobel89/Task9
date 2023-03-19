using ConsoleTables;
using Task9.Functions.Simulation;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;
using Task9.View.Interface;

namespace Task9.View
{
    public class ShipDisplay : IShipDisplay
    {
        //private readonly IOutput output;
        //public ShipDisplay(IOutput output)
        //{
        //    this.output = output;
        //}
        public void GetList()
        {
            var shipList = new ShipRepository().GetAllShips();
            DisplayInTable((List<Ship>)shipList);
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
        private string GetFactionName(int id)
        {
            return new FactionRepository().GetName(id);
        }
        private string GetGunName(int id)
        {
            return new GunRepository().GetName(id);
        }
    }
}
