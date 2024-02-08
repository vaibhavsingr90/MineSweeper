using Minesweeper.Model;
using Minesweeper.View;
using System;

namespace Minesweeper.Controller
{
    public class GameController
    {
        private readonly Model.GameModel gameModel;
        private readonly View.GameView gameView;

        public GameController(Model.GameModel model, View.GameView view)
        {
            gameModel = model;
            gameView = view;
        }

        /// <summary>
        
        /// The StartGame method orchestrates the Minesweeper gameplay loop,handling grid setup, user input, 
        /// and displaying the grid until the game concludes with a win or loss.
        /// </summary>
        public void StartGame()
        {
            bool playAgain = true;

            while (playAgain)
            {
                gameView.ShowWelcomeMessage();
                var size = GetUserInput("Enter the size of the grid (e.g. 4 for a 4x4 grid): ", 2, 10);
                var minesCount = GetUserInput("Enter the number of mines to place on the grid (maximum is 35% of the total squares): ", 1, 35);
                gameModel.InitializeGame(size, minesCount);
                gameView.DisplayGrid(gameModel.Grid, false); // Initially hide mines

                while (gameModel.GameState == Model.GameState.InProgress)
                {
                    string userInput = gameView.GetUserInput();
                    gameModel.ProcessUserInput(userInput);
                    gameView.DisplayGrid(gameModel.Grid, gameModel.GameState == Model.GameState.Lose); // Show mines if game over

                    if (gameModel.GameState == Model.GameState.Win)
                    {
                        gameView.ShowWinMessage();
                        break; // Exit the inner loop if the game is won
                    }
                    else if (gameModel.GameState == Model.GameState.Lose)
                    {
                        gameView.ShowLoseMessage();
                        break; // Exit the inner loop if the game is lost
                    }
                }

                // Prompt user to play again
                Console.WriteLine("Do you want to play again? (y/n)");
                string playAgainInput = Console.ReadLine();
                playAgain = (playAgainInput.Trim().ToLower() == "y");
            }
        }

        /// <summary>
        /// The GetUserInput method prompts the user for input within a specified range, 
        /// continually prompting until valid input is provided.
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

