using Task9.InputOutputSystem.Interface;

namespace Task9.Functions.Simulation
{
    public class End
    {
        private readonly IOutput output;
        private readonly List<Fleet> fleet1;
        private readonly List<Fleet> fleet2;
        private readonly List<Fleet> graveyard;

        public End(IOutput output, List<Fleet> fleet1, List<Fleet> fleet2, List<Fleet> graveyard)
        {
            this.output = output;
            this.fleet1 = fleet1;
            this.fleet2 = fleet2;
            this.graveyard = graveyard;
        }
        public void Run()
        {
            ShowWinner();
            BattleSummary();
        }
        private void ShowWinner()
        {
            string fleetName;
            if (fleet1.Count < fleet2.Count)
            {
                fleetName = "Flota 2";
                output.ShowMessage("Wygrywa: " + fleetName);
            }
            else
            {
                fleetName = "Flota 1";
                output.ShowMessage("Wygrywa: " + fleetName);
            }
        }
        private void BattleSummary()
        {
            output.ShowMessage("Flota 1 straciła: ");
            if (graveyard.Any(i => i.FleetNumber == 1))
            {
                foreach (var info in graveyard.Where(i => i.FleetNumber == 1))
                {
                    output.ShowMessage(info.Ship.Name);
                }
            }
            else
            {
                output.ShowMessage("0 strat");
            }
            if (graveyard.Any(i => i.FleetNumber == 1))
            {
                output.ShowMessage("Flota 2 straciła: ");
                foreach (var info in graveyard.Where(i => i.FleetNumber == 2))
                {
                    output.ShowMessage(info.Ship.Name);
                }
            }
            else
            {
                output.ShowMessage("0 strat");
            }
        }
    }
}
