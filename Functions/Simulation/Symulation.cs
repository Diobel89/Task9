using Task9.InputOutputSystem.Interface;

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
            numberOfShips = input.GetIntValue("Podaj ilość statków na każdą z flot (np 20 = każda z flot będzie posiadałą po 20 okrętów)");
        }
        private void SetShipType(int numberOfShips)
        {
            for (int index = 0; index < numberOfShips * 2; index++)
            {
                output.ShowMessage("In development");
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
