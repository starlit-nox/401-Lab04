class Board
{
    // Tic Tac Toe Gameboard states
    public string[,] GameBoard = new string[,]
    {
        {"1", "2", "3"},
        {"4", "5", "6"},
        {"7", "8", "9"},
    };

    public int Size { get; } = 3; // Set the size of the board to 3x3.

    // Method to display the Tic Tac Toe board on the console
    public void DisplayBoard()
    {
        Console.WriteLine("-------------");
        for (int row = 0; row < 3; row++)
        {
            Console.Write("| ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write(GameBoard[row, col] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------");
        }
    }
}
