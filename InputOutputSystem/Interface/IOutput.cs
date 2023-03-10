namespace Task9.InputOutputSystem.Interface
{
    public interface IOutput
    {
        public void CleanScreen();
        public void ShowMessage(string message);
        public void ShowInt(int value);
    }
}
