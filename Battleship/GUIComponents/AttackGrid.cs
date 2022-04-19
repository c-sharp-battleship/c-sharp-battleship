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
    class AttackGrid : Canvas
    {
        public AttackGrid(double width, double height, double pixelgridsize) : base()
        {
            // Load the GridSquares and put them on the DefenseGrid.
            int Reverse = 30;
            for (int col = 0; col < width / pixelgridsize; col++)
            {
                for (int row = 0; row < width / pixelgridsize; row++)
                {
                    GridSquare myButton = new GridSquare(Reverse + ((row + 1) * 0.001), 2, Reverse + ((row + 1) * 0.1).ToString());
                    myButton.Content = Reverse + ((row + 1) * 0.001).ToString();
                    myButton.Width = pixelgridsize;
                    Canvas.SetTop(myButton, row * pixelgridsize);
                    Canvas.SetLeft(myButton, col * pixelgridsize);
                    myButton.Left_Comp_ParentLeft = col * pixelgridsize;
                    myButton.Top_Comp_ParentTop = row * pixelgridsize;

                    // Add This button to my grid location
                    this.Children.Add(myButton);
                }
                Reverse--;
            }
        }
    }
}
