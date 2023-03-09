namespace Task9.Validation
{
    public class Validate
    {
        private bool isParsable;
        public bool Int(string temp)
        {
            isParsable = CheckInt(temp);
            return isParsable;
        }
        private bool CheckInt(string temp)
        {
            isParsable = int.TryParse(temp, out _);
            return isParsable;
        }
    }
}