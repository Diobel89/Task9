namespace Task9.Parse
{
    public class StringParseTo
    {
        private int integer;
        public int Int(string temp)
        {
            integer = int.Parse(temp);
            return integer;
        }
    }
}
