namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of GameModel and GameView
            var gameModel = new Model.GameModel();
            var gameView = new View.GameView();

            // Pass instances of GameModel and GameView to the GameController constructor
            var gameController = new Controller.GameController(gameModel, gameView);
            gameController.StartGame();
        }
    }
}
