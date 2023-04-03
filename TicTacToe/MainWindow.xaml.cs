using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TicTacToeLib;
namespace Exercice21
{
  public partial class MainWindow : Window
  {
    private const int SIZE = TicTacToe.SIZE;

    private Image[,] images;
    private char[,] grid;
    private char currentPlayer;

    public MainWindow()
    {
      InitializeComponent();

      InitView();
      InitModel();
      UpdateView();
    }

    private void InitView()
    {
      var borderStyle = FindResource("GridLine") as Style;
      var imageStyle = FindResource("GridImage") as Style;
      var buttonTemplate = FindResource("GridButton") as ControlTemplate;

      images = new Image[SIZE, SIZE];
      for (var x = 0; x < SIZE; x++)
      {
        gameGrid.ColumnDefinitions.Add(new ColumnDefinition());
        gameGrid.RowDefinitions.Add(new RowDefinition());

        for (var y = 0; y < SIZE; y++)
        {
          images[x, y] = CreateCell(gameGrid, y, x, borderStyle, buttonTemplate, imageStyle);
        }
      }
    }

    private Image CreateCell(
        Grid grid,
        int x,
        int y,
        Style borderStyle,
        ControlTemplate buttonTemplate,
        Style imageStyle
        )
    {
      var image = new Image();
      image.Style = imageStyle;

      var button = new Button();
      button.Template = buttonTemplate;
      button.Click += (_, _) => OnCellClick(x, y);

      var innerGrid = new Grid();
      innerGrid.Children.Add(image);
      innerGrid.Children.Add(button);

      var border = new Border();
      border.BorderThickness = new Thickness
      {
        Top = y > 0 ? 3 : 0,
        Right = x < SIZE - 1 ? 3 : 0,
        Bottom = y < SIZE - 1 ? 3 : 0,
        Left = x > 0 ? 3 : 0
      };
      border.Style = borderStyle;
      border.Child = innerGrid;

      Grid.SetColumn(border, x);
      Grid.SetRow(border, y);
      grid.Children.Add(border);

      return image;
    }

    private void InitModel()
    {
      currentPlayer= TicTacToe.StartNewGame(SIZE, out grid);
    }

    private void UpdateView()
    {
      var ySize = grid.GetLength(0);
      var xSize = grid.GetLength(1);

      for (int x = 0; x < xSize; x++)
        for (int y = 0; y < ySize; y++)
          images[x, y].Source = GetImage(grid[x, y]);
    }

    private void OnCellClick(int x, int y)
    {
      currentPlayer = TicTacToe.PutMarkAt(y, x, grid, currentPlayer);
      UpdateView();

      var winner = TicTacToe.FindWinner(grid);
      if (winner != TicTacToe.NONE)
      {
        MessageBox.Show($"Le joueur {winner} a gagné!", "Félicications!", MessageBoxButton.OK, MessageBoxImage.Information);
        currentPlayer = TicTacToe.StartNewGame(SIZE, out grid);
        UpdateView();
      }
      else if (TicTacToe.IsGameADraw (grid))
      {
        MessageBox.Show($"Partie nulle.", "Oh. Dommage.", MessageBoxButton.OK, MessageBoxImage.Information);
        currentPlayer = TicTacToe.StartNewGame(SIZE, out grid);
        UpdateView();
      }
    }

    private static ImageSource GetImage(char value)
    {
      return value switch
      {
        TicTacToe.CROSS => new BitmapImage(new Uri("/Images/Cross.png", UriKind.Relative)),
        TicTacToe.CIRCLE => new BitmapImage(new Uri("/Images/Circle.png", UriKind.Relative)),
        _ => null,
      };
    }
  }
}
