using Task9.InputOutputSystem.Interface;

namespace Task9.Functions.Simulation
{
    public class GatherData : Fleet
    {
        private readonly IInput input;
        private readonly IOutput output;
        public GatherData(IInput input, IOutput output)
        {
            this.input = input;
            this.output = output;
        }
        public void Run()
        {
            SetShipsNumber();
            output.ShowMessage("Tsudzuku");
        }
        private void SetShipsNumber()
        {
            int fleet1, fleet2;
            fleet1 = input.GetIntValue("Podaj liczbę statkó w flocie1:");
            fleet2 = input.GetIntValue("Podaj liczbę statkó w flocie1:");
            var info = String.Join(" ","Flota1: [" + fleet1 + "] Flota2: [" + fleet2 + "]");
            output.ShowMessage(info);
        }
    }
}