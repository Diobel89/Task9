namespace Task9.InputOutputSystem.Interface
{
    public interface IInput
    {
        public string GetStringValue(string value);
        public int GetIntValue(string value);
        public int GetId(string fromWhere);
    }
}
