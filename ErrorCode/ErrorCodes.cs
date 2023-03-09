using System.ComponentModel;

namespace Task9.ErrorCode
{
    public class ErrorCodes
    {
        public void Message(int errorCode)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            switch(errorCode)
            {
                case 0:
                    {
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        NoError();
                        break;
                    }
                case 1:
                    {
                        Error001();
                        break;
                    }
                case 2:
                    {
                        Error002();
                        break;
                    }
                case 3:
                    {
                        Error003();
                        break;
                    }
                case 4:
                    {
                        Error004();
                        break;
                    }
                case 5:
                    {
                        Error005();
                        break;
                    }
                case 6:
                    {
                        Error006();
                        break;
                    }
                case 7:
                    {
                        Error007();
                        break;
                    }
            }
            Console.ResetColor();
        }
        private void NoError()
        {
            Console.WriteLine("All Green!");
        }
        private void Error001()
        {
            Console.WriteLine("Error 001!"); // error for incorect int (input is not int)
        }
        private void Error002()
        {
            Console.WriteLine("Error 002!"); // int too large or too small
        }
        private void Error003()
        {
            Console.WriteLine("Error 003!"); // no record in database
        }
        private void Error004()
        {
            Console.WriteLine("Error 004!"); // for empty string
        }
        private void Error005() // error for no file
        {
            Console.WriteLine("Error 005!"); 
        }
        private void Error006() // error for empty file
        {
            Console.WriteLine("Error 006!");
        }
        private void Error007() // database empty
        {
            Console.WriteLine("Error 007!");
        }
    }
}
