using _401_Lab04;

class Player
{
    // properties
    public string Name { get; set; }
    /// <summary>
    /// P1 is X and P2 will be O
    /// </summary>
    public string Marker { get; set; }

    /// <summary>
    /// Flag to determine if it is the user's turn
    /// </summary>
    public bool IsTurn { get; set; }

    // method to get the desired position from the player
    public Position GetPosition(Board board)
    {
        Position desiredCoordinate = null;
        while (desiredCoordinate is null)
        {
            Console.WriteLine($"{Name}, it is your turn. Please select a location (1-9):");
            int.TryParse(Console.ReadLine(), out int position);
            desiredCoordinate = PositionForNumber(position);

            // Check if the desired position is valid and not occupied.
            if (desiredCoordinate != null)
            {
                int row = desiredCoordinate.Row;
                int col = desiredCoordinate.Column;

                if (int.TryParse(board.GameBoard[row, col], out int _))
                {
                    // Update the board with the player's marker.
                    board.GameBoard[row, col] = Marker;
                    IsTurn = false; // Switch turn to the other player.
                }
                else
                {
                    Console.WriteLine("This space is already occupied. Try again.");
                    desiredCoordinate = null;
                }
            }
            else
            {
                Console.WriteLine("Invalid position. Try again.");
            }
        }

        return desiredCoordinate;
    }

    // method to convert a number (1-9) to a position on the game board
    public static Position PositionForNumber(int position)
    {
        switch (position)
        {
            case 1: return new Position(0, 0); // Top Left
            case 2: return new Position(0, 1); // Top Middle
            case 3: return new Position(0, 2); // Top Right
            case 4: return new Position(1, 0); // Middle Left
            case 5: return new Position(1, 1); // Middle Middle
            case 6: return new Position(1, 2); // Middle Right
            case 7: return new Position(2, 0); // Bottom Left
            case 8: return new Position(2, 1); // Bottom Middle 
            case 9: return new Position(2, 2); // Bottom Right

            default: return null;
        }
    }

    // method for the player to take their turn
    public void TakeTurn(Board board)
    {
        IsTurn = true;

        Console.WriteLine($"{Name} it is your turn");

        Position position = GetPosition(board);

        if (int.TryParse(board.GameBoard[position.Row, position.Column], out int _))
        {
            board.GameBoard[position.Row, position.Column] = Marker;
        }
        else
        {
            Console.WriteLine("This space is already occupied");
        }
    }
}
