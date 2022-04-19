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
    class DefenseGrid : Canvas
    {
        private const ushort NUM_SHIPS = 5;
        private List<Rectangle> Ships;

        public DefenseGrid(double width, double height, double pixelgridsize) : base()
        {
            base.Width = width;
            base.Height = height;

            this.Ships = new List<Rectangle>();

            Rectangle tempRectangle;
            for (int i = 0; i < NUM_SHIPS; i++)
            {
                // Code to place ships on the screen.
                tempRectangle = new Rectangle();
                tempRectangle.Width = pixelgridsize;
                tempRectangle.Height = pixelgridsize * 5;
                tempRectangle.Fill = Brushes.Red;
                tempRectangle.Name = "TempRectangle"  +  i.ToString();

                Canvas.SetTop(tempRectangle, 1 * pixelgridsize);
                Canvas.SetLeft(tempRectangle, (1 * pixelgridsize) + i);

                this.Ships.Add(tempRectangle);
            }

            // Load the GridSquares and put them on the DefenseGrid.
            int Reverse = 30;
            for (int col = 0; col < width / pixelgridsize; col++)
            {
                for (int row = 0; row < width / pixelgridsize; row++) //Rows Button loader 
                {
                    GridSquare myButton = new GridSquare(Reverse + ((row + 1) * 0.001), 1, Reverse + ((row + 1) * 0.1).ToString());
                    myButton.Content = Reverse + ((row + 1) * 0.001).ToString();
                    myButton.Width = pixelgridsize;
                    Canvas.SetTop(myButton, row * pixelgridsize);
                    Canvas.SetLeft(myButton, col * pixelgridsize);
                    myButton.Left_Comp_ParentLeft = col * pixelgridsize;
                    myButton.Top_Comp_ParentTop = row * pixelgridsize;
                    this.Children.Add(myButton);//Add This button to my grid location

                    // For each GridSqure, add a DragEventHandler to these buttons so that the ships can move over them.
                    foreach(Rectangle testRectangle in this.Ships)
                    {
                        testRectangle.DragOver += new DragEventHandler(Onbuttondragover);

                        void Onbuttondragover(object sender, DragEventArgs e)
                        {
                            Point GrabPos = e.GetPosition(this);
                            Canvas.SetTop(testRectangle, myButton.Top_To_ParentTop);
                            Canvas.SetLeft(testRectangle, myButton.Left_Comp_ParentLeft);
                        }
                    }
                }
                Reverse--;
            }

            foreach (Rectangle testRectangle in this.Ships)
            {
                testRectangle.MouseMove += new MouseEventHandler(Rectangle_Mousemove);

                void Rectangle_Mousemove(object sender, MouseEventArgs e)
                {
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        Point GrabPos = e.GetPosition(this);
                        Canvas.SetTop(testRectangle, GrabPos.Y);
                        Canvas.SetLeft(testRectangle, GrabPos.X);
                        DragDrop.DoDragDrop(testRectangle, new DataObject(testRectangle), DragDropEffects.Move);
                    }
                }

                this.Children.Add(testRectangle);
            }
        }
   }
}
