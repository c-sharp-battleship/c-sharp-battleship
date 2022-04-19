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
    class MainCanvas : Canvas
    {
        public MainCanvas() : base()
        {
            double gridSize = 19.2;
            int gridSquareCount = 10;

            double boardSize = gridSize * gridSquareCount;

            DefenseGrid defenseGrid = new DefenseGrid(boardSize, boardSize, gridSize);
            AttackGrid attackGrid = new AttackGrid(boardSize, boardSize, gridSize);
            Canvas.SetLeft(attackGrid, gridSize* gridSquareCount);

            base.Children.Add(defenseGrid);
            base.Children.Add(attackGrid);
        }
    }
}
