using Task9.Functions.Simulation;
using Task9.InputOutputSystem.Interface;
using Task9.Models.Context;
using Task9.View.Interface;

namespace Task9.View
{
    public class SimulationDisplay : ISimulationDisplay
    {
        private readonly IOutput output;
        private string[,] board; 
        public SimulationDisplay(IOutput output)
        {
            this.output = output;
        }
        public void Display(List<Fleet> team1, List<Fleet> team2)
        {

            board = SetBoard(team1, team2);
            board = GenerateSea();
            board = SetShipsOnBoard(team1, team2);
            for (int indexY = 0; indexY < board.GetLength(0); indexY++)
            {
                for (int indexX = 0; indexX < board.GetLength(1); indexX++)
                {
                    Console.Write(board[indexY, indexX]);
                }
                Console.WriteLine();
            }
        }
        private string[,] SetBoard(List<Fleet> team1, List<Fleet> team2)
        {
            int temp1 = team1.Count();
            int temp2 = team2.Count();
            if (temp1 < temp2)
            {
                return new string[temp2 * 2 + 1, 10];
            }
            else
            {
                return new string[temp1 * 2 + 1, 10];
            }
        }
        private string[,] SetShipsOnBoard(List<Fleet> team1, List<Fleet> team2)
        {
            int YAxis = 1;
                foreach (var info in team1)
                {
                    if (YAxis != board.GetLength(0))
                    {
                        board[YAxis, 1] = new FactionRepository().GetIcon(info.Ship.FactionId);
                        YAxis += 2;
                    }
                }
            YAxis = 1;
                foreach (var info in team2)
                {
                    if (YAxis != board.GetLength(0))
                    {
                        board[YAxis, 8] = new FactionRepository().GetIcon(info.Ship.FactionId);
                        YAxis += 2;
                    }
                }
            return board;
        }
        private string[,] GenerateSea()
        {
            for (int indexY = 0; indexY < board.GetLength(0); indexY++)
            {
                for (int indexX = 0; indexX < board.GetLength(1); indexX++)
                {
                    board[indexY, indexX] = "~~";
                }
                Console.WriteLine();
            }
            return board;
        }
    }
}
