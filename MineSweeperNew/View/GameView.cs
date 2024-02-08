using System;

namespace Minesweeper.View
{
    public class GameView
    {     /// <summary>
           // Displays the welcome message
          /// </summary>

        public void ShowWelcomeMessage()
        {
            Console.WriteLine("Welcome to Minesweeper!");
        }

        /// <summary>
        // Displays the game grid
        /// </summary>
     
        public void DisplayGrid(char[,] grid, bool showMines)
        {
            Console.Write("  ");
            for (int i = 1; i <= grid.GetLength(1); i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.Write((char)('A' + i) + " ");
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    char cellValue = grid[i, j];
                    if (!showMines && cellValue == '*')
                        cellValue = '_'; // Hide the mine
                    Console.Write(cellValue + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        // Gets user input
        /// </summary>
        

        public string GetUserInput()
        {
            Console.Write("Select a square to reveal (e.g. A1): ");
            return Console.ReadLine();
        }

        /// <summary>
        // Shows win message
        /// </summary>

        public void ShowWinMessage()
        {
            Console.WriteLine("Congratulations, you have won the game!");
        }

        /// <summary>
        // Shows lose message 
        /// </summary>

        public void ShowLoseMessage()
        {
            Console.WriteLine("Oh no, you detonated a mine! Game over.");
        }
    }
}
