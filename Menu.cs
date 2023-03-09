using Task9.InputOutputSystem.Interface;

namespace Task9
{
    public class Menu
    {
        private readonly IInput input;
        private readonly IOutput output;
        public Menu(IInput input, IOutput output)
        {
            this.input = input;
            this.output = output;
        }
        public void Run()
        {

        }
    }
}
