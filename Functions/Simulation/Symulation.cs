using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Validation;
using Task9.View;

namespace Task9.Functions.Simulation
{
    public class Symulation : Fleet
    {
        private readonly IInput input;
        private readonly IOutput output;
        public Symulation(IInput input, IOutput output)
        {
            this.input = input;
            this.output = output;
        }
        public void Run()
        {
            output.ShowMessage("In development");
        }
        private void GatherData()
        {
            output.ShowMessage("In development");
        }
        private void SetNumberOfShips()
        {
            int numberOfShips;
            //numberOfShips = input.GetIntValue("Podaj ilość statków na każdą z flot (np 20 = każda z flot będzie posiadałą po 20 okrętów)");
            for (FleetNumber = 1; FleetNumber < 2; FleetNumber++)
            {
                numberOfShips = input.GetIntValue("Podaj ilość statków dla " + FleetNumber + ":");
                SetShipType(numberOfShips, FleetNumber);
            }
        }
        private void SetShipType(int numberOfShips, int fleetNumber)
        {
            int id;
            for (int index = 0; index < numberOfShips; index++)
            {
                bool exit = false;
                do
                {
                    new ShipDisplay(output).GetList();
                    id = input.GetIntValue("Wybierz ID Statku");
                    exit = new Validate().MaxShipId(id);
                } while (!exit);
                AddShipToFleet(fleetNumber, id);
            }
        }
        private void AddShipToFleet(int fleetNumber, int id)
        {
            if (fleetNumber == 1)
            {
                Ship = new Ship().GetShip(id);
                ShipTotalDamage = new Fleet().SetTotalDamage(id);
                fleet1.Add(new Fleet { Ship = Ship, ShipTotalDamage = ShipTotalDamage, FleetNumber = fleetNumber});
            }
            if (fleetNumber == 2)
            {
                Ship = new Ship().GetShip(id);
                ShipTotalDamage = new Fleet().SetTotalDamage(id);
                fleet2.Add(new Fleet { Ship = Ship, ShipTotalDamage = ShipTotalDamage, FleetNumber = fleetNumber });
            }
        }
        private void ChooceMap()
        {
            output.ShowMessage("In development");
        }
        private void Start()
        {
            output.ShowMessage("In development");
        }
        private void End()
        {
            output.ShowMessage("In development");
        }
    }
}
