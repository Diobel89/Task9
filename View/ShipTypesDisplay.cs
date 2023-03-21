using Task9.InputOutputSystem.Interface;
using Task9.Models.Context;
using Task9.Models;
using Task9.View.Interface;
using ConsoleTables;

namespace Task9.View
{
    internal class ShipTypesDisplay : IShipTypesDisplay
    {
        private readonly IOutput output;
        public ShipTypesDisplay(IOutput output)
        {
            this.output = output;
        }
        public void GetList()
        {
            var shipTypeList = new ShipTypeRepository().GetAllShipTypes();
            DisplayInTable((List<ShipType>)shipTypeList);
        }
        private void DisplayInTable(List<ShipType> shipTypeList)
        {
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "ID", "Typ" },
                EnableCount = false
            });
            foreach (var info in shipTypeList)
            {
                table.AddRow(info.Id, info.Type);
            }
            table.Write();
        }
    }
}
