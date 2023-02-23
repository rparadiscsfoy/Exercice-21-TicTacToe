namespace TicTacToeLib
{

  public class TicTacToe
  {
    public const char NONE = ' ';
    public const char CROSS = 'X';
    public const char CIRCLE = 'O';
    public const int SIZE = 3;

    public static char StartNewGame(int size, out char[,] grid)
    {
      throw new System.NotImplementedException ();
    }

    public static char PutMarkAt(int column, int row, char[,] grid, char currentPlayer)
    {
      throw new System.NotImplementedException ();
    }

    public static char FindWinner(char[,] grid)
    {
      throw new System.NotImplementedException ();
    }

    public static bool IsGameADraw(char[,] grid)
    {
      throw new System.NotImplementedException ();
    }
  }
}