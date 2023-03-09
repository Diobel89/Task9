using Task9.InputOutputSystem.Interface;

namespace Task9.InputOutputSystem
{
    public class Input : IInput
    {
        private readonly IOutput _output;
        public Input()
        {
            _output = new Output();
        }
        public string GetStringValue(string message)
        {
            _output.ShowMessage(message);
            string tempInput = Console.ReadLine();
            return tempInput;
        }
        public int GetIntValue(string message)
        {
            int intOut;
            _output.ShowMessage(message);
            string tempInput = Console.ReadLine();
            intOut = int.Parse(tempInput);
            return intOut;
        }
    }
}
