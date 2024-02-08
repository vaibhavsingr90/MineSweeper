using System;
using System.Collections.Generic;

namespace Minesweeper.Model
{
    public enum GameState
    {
        InProgress,
        Win,
        Lose
    }

    public class GameModel
    {
        public char[,] Grid { get; private set; }
        private int gridSize;
        private int numberOfMines;
        public  int revealedCells;
        private HashSet<(int, int)> mines;
        public GameState GameState { get; private set; }

        public GameModel()
        {
            GameState = GameState.InProgress;
        }
        // Initializes the game
        public void InitializeGame(int size, int minesCount)
        {
            if (size <= 0 || size > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Grid size must be between 1 and 10.");
            }

            if (minesCount <= 0 || minesCount >= size * size)
            {
                throw new ArgumentOutOfRangeException(nameof(minesCount), "Number of mines must be greater than 0 and less than total grid size.");
            }

            gridSize = size;
            numberOfMines = minesCount;
            revealedCells = 0;
            mines = new HashSet<(int, int)>();

            Grid = new char[gridSize, gridSize];

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Grid[i, j] = '_';
                }
            }

            Random random = new Random();
            for (int i = 0; i < numberOfMines; i++)
            {
                int x = random.Next(gridSize);
                int y = random.Next(gridSize);

                if (Grid[x, y] == '*')
                {
                    i--;
                    continue;
                }

                Grid[x, y] = '*';
                mines.Add((x, y));
            }
        }


        /// <summary>
        /// The InitializeGame method sets up the game grid with a specified size, number of mines, 
        /// and preset mine positions. It initializes the grid with underscores ('_') and places mines on the specified positions.
        /// </summary>

        public void InitializeGame(int size, int minesCount, HashSet<(int, int)> presetMines)
        {
            gridSize = size;
            numberOfMines = minesCount;
            revealedCells = 0;
            mines = presetMines;

            Grid = new char[gridSize, gridSize];

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Grid[i, j] = '_';
                }
            }

            foreach (var mine in mines)
            {
                Grid[mine.Item1, mine.Item2] = '*';
            }
        }


        // Processes user input
        public void ProcessUserInput(string input)
        {
            if (input.Length < 2 || input.Length > 3)
            {
                Console.WriteLine("Incorrect input.");
                return;
            }

            int row = input[0] - 'A';
            int col = input[1] - '1';

            if (row < 0 || row >= gridSize || col < 0 || col >= gridSize)
            {
                Console.WriteLine("Incorrect input.");
                return;
            }

            if (Grid[row, col] == '*')
            {
                GameState = GameState.Lose;
                return;
            }

            if (Grid[row, col] != '_')
            {
                Console.WriteLine("This square has already been revealed.");
                return; // Do not increment revealedCells count if already revealed
            }

            int adjacentMines = CountAdjacentMines(row, col);
            Grid[row, col] = adjacentMines == 0 ? '0' : adjacentMines.ToString()[0];
            if (Grid[row, col] != ' ') // Increment revealedCells count only if a new cell is revealed
            {
                revealedCells++;
            }

            if (revealedCells == gridSize * gridSize - numberOfMines)
            {
                GameState = GameState.Win;
                return;
            }

            if (adjacentMines == 0)
            {
                // recursively reveal adjacent cells if current cell has no adjacent mines
                for (int i = Math.Max(0, row - 1); i <= Math.Min(gridSize - 1, row + 1); i++)
                {
                    for (int j = Math.Max(0, col - 1); j <= Math.Min(gridSize - 1, col + 1); j++)
                    {
                        if (Grid[i, j] == '_')
                        {
                            ProcessUserInput($"{(char)(i + 'A')}{(char)(j + '1')}");
                        }
                    }
                }
            }
        }


        // Counts the number of adjacent mines to a given cell
        public int CountAdjacentMines(int row, int col)
        {
            int count = 0;
            for (int i = Math.Max(0, row - 1); i <= Math.Min(gridSize - 1, row + 1); i++)
            {
                for (int j = Math.Max(0, col - 1); j <= Math.Min(gridSize - 1, col + 1); j++)
                {
                    if (mines.Contains((i, j)))
                        count++;
                }
            }
            return count;
        }

        /// <summary>
        // Handles getting user input within a range
        /// </summary>
    

        private int GetUserInput(string prompt, int min, int max)
        {
            int input;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out input) && input >= min && input <= max)
                    return input;
                else
                    Console.WriteLine($"Incorrect input. Please enter a number between {min} and {max}.");
            }
        }
    }
}
