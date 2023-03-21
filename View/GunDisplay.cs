using Task9.View.Interface;
using Task9.Models;
using Task9.Models.Context;
using ConsoleTables;
using Task9.Models.Context.Interfaces;

namespace Task9.View
{
    public class GunDisplay : IGunDisplay
    {
        private readonly IGunRepository _gunRepository;
        public GunDisplay()
        {
            _gunRepository = new GunRepository();
        }
        public void GetList()
        {
            var gunList = _gunRepository.GetAllGuns();
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
