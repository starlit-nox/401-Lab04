using _401_Lab04;

namespace Lab04_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            // setup the game by creating players and the game instance
            Player playerOne = new Player { Name = "Player One", Marker = "X" };
            Player playerTwo = new Player { Name = "Player Two", Marker = "O" };

            Game ticTacToeGame = new Game(playerOne, playerTwo);

            // start the game and get the winner
            Player winner = ticTacToeGame.Play();

            // output the result, indicates winner / draw 
            if (winner != null)
            {
                Console.WriteLine($"Congratulations, {winner.Name}! You win!");
            }
            else
            {
                Console.WriteLine("It's a draw! There is no winner.");
            }
        }
    }
}
