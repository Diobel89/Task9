using Task9.View.Interface;
using Task9.Models;
using Task9.Models.Context;
using ConsoleTables;

namespace Task9.View
{
    public class GunDisplay : IGunDisplay
    {
        public void GetList()
        {
            var gunList = new GunRepository().GetAllGuns();
            DisplayInTable((List<Gun>)gunList);
        }
        private void DisplayInTable(List<Gun> gunList)
        {
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "ID", "Gun Name", "Barrels", "Damage", "Armor", "HP" },
                EnableCount = false
            });
            foreach (var info in gunList)
            {
                table.AddRow(info.Id, info.Name, info.Barrels, info.Damage, info.Armor, info.HP);
            }
            table.Write();
        }
    }
}
