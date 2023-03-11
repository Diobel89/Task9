using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.View.Interface;

namespace Task9.View
{
    public class SimulationDisplay : ISimulationDisplay
    {
        private readonly IOutput output;
        public SimulationDisplay(IOutput output)
        {
            this.output = output;
        }
        public void Display(List<Ship> team1, List<Ship> team2)
        {

        }
    }
}
