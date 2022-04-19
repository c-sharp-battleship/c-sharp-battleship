using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Battleship.GUIComponents
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            this.InitializeComponent();

            double gridSize = 19.2;
            int gridSquareCount = 10;

            double boardSize = gridSize * gridSquareCount;

            DefenseGrid defenseGrid = new DefenseGrid(boardSize, boardSize, gridSize);
            this.Content = defenseGrid;

            /*
            AttackGrid attackGrid = new AttackGrid(boardSize, boardSize, gridSize);

            myParentCanvas.Children.Add(myRectangle);
            this.Content = myParentCanvas;
            */
        }
    }
}
