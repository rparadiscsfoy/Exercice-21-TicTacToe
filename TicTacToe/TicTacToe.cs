using System;

namespace Exercice21
{
  public class TicTacToe
  {
    public const char NONE = ' ';
    public const char CROSS = 'X';
    public const char CIRCLE = 'O';
    public const int SIZE = 3;


    public static char StartNewGame(int size, out char[,] grid)
    {
      grid = new char[size, size];
      for (int x = 0; x < size; x++)
      {
        for (int y = 0; y < size; y++)
        {
          grid[x, y] = NONE;
        }
      }
      return CROSS;

    }

    public static char PutMarkAt(int x, int y, char[,] grid, char currentPlayer)
    {
      grid[x, y] = currentPlayer;
      char nextPlayer = CROSS;
      if (CROSS == currentPlayer)
        nextPlayer = CIRCLE;

      return nextPlayer;

    }

    public static char FindWinner(char[,] grid)
    {
      bool isWinner;
      int xSize = grid.GetLength(0);
      int ySize = grid.GetLength(1);

      //Horizontal
      for (int y = 0; y < ySize; y++)
      {
        isWinner = grid[0, y] != NONE;
        for (int x = 0; x < xSize - 1; x++)
        {
          if (grid[x, y] != grid[x + 1, y])
            isWinner = false;
        }
        if (isWinner)
          return grid[0, y];
      }

      //Vertical
      for (int x = 0; x < xSize; x++)
      {
        isWinner = grid[x, 0] != NONE;
        for (int y = 0; y < ySize - 1; y++)
        {
          if (grid[x, y] != grid[x, y + 1])
            isWinner = false;
        }
        if (isWinner)
          return grid[x, 0];
      }

      // Diagonale
      // Down right
      isWinner = grid[0, 0] != NONE;
      for (int x = 0; x < xSize - 1; x++)
      {
        if (grid[x, x] != grid[x + 1, x + 1])
          isWinner = false;
      }

      if (isWinner)
        return grid[0, 0];

      //Up right
      isWinner = grid[0, ySize - 1] != NONE;
      for (int x = 0; x < xSize - 1; x++)
      {
        if (grid[x, ySize - x - 1] != grid[x + 1, ySize - x - 2])
          isWinner = false;
      }

      if (isWinner)
        return grid[0, ySize - 1]; ;
      return NONE;
      
    }

    public static bool IsDrawGame(char[,] grid)
    {
      int xSize = grid.GetLength(0);
      int ySize = grid.GetLength(1);
      bool isDrawGame = true;
      for (int x = 0; x < xSize; x++)
      {
        for (int y = 0; y < ySize; y++)
        {
          if (grid[x, y] == NONE)
            isDrawGame = false;
        }
      }
      return isDrawGame && (NONE == FindWinner(grid));
    }
  }
}
