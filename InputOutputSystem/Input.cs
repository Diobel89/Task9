using Task9.InputOutputSystem.Interface;
using Task9.Validation;

namespace Task9.InputOutputSystem
{
    public class Input : IInput
    {
        private readonly IOutput output;
        public Input()
        {
            output = new Output();
        }
        public string GetStringValue(string message)
        {
            output.ShowMessage(message);
            string tempInput = Console.ReadLine();
            return tempInput;
        }
        public int GetIntValue(string message)
        {
            bool isParsable = false;
            int intOut = 0;
            output.ShowMessage(message);
            string tempInput = Console.ReadLine();
            while (!isParsable)
            {
                isParsable = new Validate().Int(tempInput);
                if (!isParsable)
                {
                    output.ShowMessage("To nie liczba!");
                }else
                {
                    intOut = int.Parse(tempInput);
                    return intOut;
                }
            }

            return intOut;
        }
    }
}
