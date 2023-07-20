namespace _401_Lab04
{
    class Game
    {
        // properties
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public Player Winner { get; set; }
        public Board Board { get; set; }

        // constructor
        public Game(Player p1, Player p2)
        {
            PlayerOne = p1;
            PlayerTwo = p2;
            Board = new Board();
        }

        // method to start the game
        public Player Play()
        {
            Player currentPlayer = PlayerOne;
            int turnCount = 0;

            // continue the game until a winner is found or the board is full (draw)
            while (turnCount < Board.Size * Board.Size && !CheckForWinner(Board))
            {
                // display the board before each turn
                Board.DisplayBoard();

                // ask the current player to make their move
                currentPlayer.TakeTurn(Board);

                // check if the current player wins after their move
                if (CheckForWinner(Board))
                {
                    Winner = currentPlayer;
                    break;
                }

                // switch to the next player for the next turn
                currentPlayer = NextPlayer();

                // increment the turn count
                turnCount++;
            }

            // display the final state of the board
            Board.DisplayBoard();

            if (Winner != null)
            {
                Console.WriteLine($"Congratulations, {Winner.Name}! You are the winner!");
            }
            else
            {
                Console.WriteLine("It's a draw! There's no winner.");
            }

            return Winner;
        }

        // method to check if there is a winner on the board
        public bool CheckForWinner(Board board)
        {
            // the existing logic for checking the winner is correct
            int[][] winners = new int[][]
            {
                new[] {1,2,3},
                new[] {4,5,6},
                new[] {7,8,9},

                new[] {1,4,7},
                new[] {2,5,8},
                new[] {3,6,9},

                new[] {1,5,9},
                new[] {3,5,7}
            };

            for (int i = 0; i < winners.Length; i++)
            {
                Position p1 = Player.PositionForNumber(winners[i][0]);
                Position p2 = Player.PositionForNumber(winners[i][1]);
                Position p3 = Player.PositionForNumber(winners[i][2]);

                string a = board.GameBoard[p1.Row, p1.Column];
                string b = board.GameBoard[p2.Row, p2.Column];
                string c = board.GameBoard[p3.Row, p3.Column];

                // determine a winner has been reached
                if (a == b && b == c && !string.IsNullOrEmpty(a))
                    return true;
            }

            return false;
        }

        // method to get the next player
        public Player NextPlayer()
        {
            // simply return the next player based on whose turn it is
            return PlayerOne.IsTurn ? PlayerTwo : PlayerOne;
        }

        // method to switch players (not needed since we handle player switching in the Play() method)
        public void SwitchPlayer()
        {
            // this method is not needed since we handle player switching in the Play() method
        }
    }
}
