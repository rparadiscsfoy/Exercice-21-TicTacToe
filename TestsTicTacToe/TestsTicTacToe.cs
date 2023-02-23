using TicTacToeLib;
using Xunit;

namespace TicTacToeTests;

public class TestsTicTacToe
{
  const char X = TicTacToe.CROSS;
  const char O = TicTacToe.CIRCLE;
  const char N = TicTacToe.NONE;

  [Fact]
  public void StartNewGame_InitGame_NoneInAllCells ()
  {
    char[,] grid;
    char firstPlayer = TicTacToe.StartNewGame (TicTacToe.SIZE, out grid);

    Assert.Equal (TicTacToe.CROSS, firstPlayer);
    for (int column = 0; column < TicTacToe.SIZE; column++)
    {
      for (int row = 0; row < TicTacToe.SIZE; row++)
      {
        Assert.Equal (N, grid[column, row]);
      }
    }
  }

  [Fact]
  public void PutMarkAt_XInEmptyCell_CellHasXAndNextPlayerIsO ()
  {
    const char CURRENT_PLAYER = X;
    char[,] grid = {{X,N,N},
                      {N,N,N},
                      {O,X,X}
      };

    char nextPlayer = TicTacToe.PutMarkAt (1, 0, grid, CURRENT_PLAYER);
    Assert.Equal (CURRENT_PLAYER, grid[0, 1]);
    Assert.Equal (O, nextPlayer);

  }
  [Fact]
  public void PutMarkAt_OInEmptyCell_CellHasOAndNextPlayerIsX ()
  {
    const char CURRENT_PLAYER = O;
    char[,] grid = {{X,N,N},
                      {N,N,N},
                      {O,X,X}
      };

    char nextPlayer = TicTacToe.PutMarkAt (1, 0, grid, CURRENT_PLAYER);
    Assert.Equal (CURRENT_PLAYER, grid[0, 1]);
    Assert.Equal (X, nextPlayer);
  }

  [Fact]
  public void PutMarkAt_OInCellContainingX_CellStillHasXAndNextPlayerIsO ()
  {
    const char CURRENT_PLAYER = O;
    char[,] grid = {{X,N,N},
                      {N,N,N},
                      {O,X,X}
      };

    char nextPlayer = TicTacToe.PutMarkAt (0, 0, grid, CURRENT_PLAYER);
    Assert.Equal (X, grid[0, 0]);
    Assert.Equal (CURRENT_PLAYER, nextPlayer);
  }

  // A COMPLÉTER AVEC LES TESTS DE FIN DE PARTIE ET DE PARTIE NULLE
}