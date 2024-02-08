# Minesweeper

Welcome to Minesweeper, a classic single-player puzzle game where the objective is to clear a minefield without detonating any mines.

## Features

- **Dynamic grid size:** Choose the size of the grid (between 2x2 and 10x10) to customize your gameplay experience.
- **Adjustable mine count:** Specify the number of mines to place on the grid (up to 35% of the total squares) to increase or decrease the game's difficulty.
- **Simple user interface:** Interact with the game using intuitive commands to select squares and reveal their contents.
- **Win and lose conditions:** Win the game by revealing all safe squares without detonating any mines, but be careful—detonating a mine results in an immediate loss.

## How to Play

### Start the Game

1. Run the application.
2. Follow the prompts to specify the grid size and number of mines.
3. The game will initialize and display the grid with hidden squares.

### Reveal Squares

- Enter coordinates (e.g., A1, B3) to select a square and reveal its contents.
- If the selected square contains a mine, the game ends immediately.
- Otherwise, the square will display the number of adjacent mines (if any) or remain blank if there are none nearby.

### Win or Lose

- Continue revealing squares until either all safe squares are cleared (win) or a mine is detonated (lose).
- Upon winning or losing, the game will display a corresponding message and prompt you to play again.

### Play Again

- After completing a game, you have the option to play again by entering 'y' or exit the application by entering 'n'.

## How to Run

1. Clone or download the repository.
2. **Open the Solution:** Open your Minesweeper solution in your preferred IDE. This could be Visual Studio, Visual Studio Code, JetBrains Rider, or any other IDE that supports C# development.
3. **Set Startup Project:** Ensure that the project containing your Program.cs file (typically named Minesweeper or similar) is set as the startup project. You can usually do this by right-clicking on the project in the Solution Explorer and selecting "Set as Startup Project".
4. **Build Solution:** Build the solution to compile all the project files. This step ensures that there are no compilation errors before running the application.
5. **Run the Application:** Run the application by clicking on the "Start" or "Run" button in your IDE's toolbar, or by pressing the appropriate keyboard shortcut (usually F5 or Ctrl+F5). This action will execute the Main method in your Program.cs file, starting the Minesweeper game.
6. **Follow On-Screen Prompts:** Once the application starts, follow the on-screen prompts to specify the grid size, number of mines, and proceed with playing the game.

