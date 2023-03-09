using Task9.InputOutputSystem.Interface;

namespace Task9.InputOutputSystem
{
    public class Output : IOutput
    {
        public void CleanScreen()
        {
            Console.Clear();
        }
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
