using ConsoleTables;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;
using Task9.View.Interface;

namespace Task9.View
{
    public class FactionDisplay : IFactionDisplay
    {
        private readonly IOutput output;
        public FactionDisplay(IOutput output)
        {
            this.output = output;
        }
        public void GetList()
        {
            using (var db = new FactionRepository())
            {
                var factionList = db.GetAllFactions();
                DisplayInTable((List<Faction>)factionList);
            }
        }
        private void DisplayInTable(List<Faction> factionList)
        {
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "ID", "Faction Name", "Icon" },
                EnableCount = false
            });
            foreach (var info in factionList)
            {
                table.AddRow(info.Id, info.Name, info.Icon);
            }
            table.Write();
        }
    }
}
