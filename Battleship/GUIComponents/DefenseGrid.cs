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

            for (int i = 0; i < NUM_SHIPS; i++)
            {
                // Code to place ships on the screen.
                Rectangle myRectangle = new Rectangle();
                myRectangle.Width = pixelgridsize;
                myRectangle.Height = pixelgridsize * 5;
                myRectangle.Fill = Brushes.Red;
                myRectangle.Name = "Myrectangle"  +  i.ToString();

                Canvas.SetTop(myRectangle, 0);
                Canvas.SetLeft(myRectangle, 0);

                myRectangle.MouseMove += new MouseEventHandler(myRectangle_Mousemove);

                void myRectangle_Mousemove(object sender, MouseEventArgs e)
                {
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        Point GrabPos = e.GetPosition(this);
                        Canvas.SetTop(myRectangle, GrabPos.Y);
                        Canvas.SetLeft(myRectangle, GrabPos.X);
                        DragDrop.DoDragDrop(myRectangle, new DataObject(myRectangle), DragDropEffects.Move);
                    }
                }

                this.Ships.Add(myRectangle);
            }

            // Code to place ships on the screen.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = pixelgridsize;
            myRectangle.Height = pixelgridsize * 5;
            myRectangle.Fill = Brushes.Red;

            Canvas.SetTop(myRectangle, 0);
            Canvas.SetLeft(myRectangle, 0);

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

                    /*
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
                    */
                }
                Reverse--;
            }

            foreach (Rectangle testRectangle in this.Ships)
            {
                this.Children.Add(testRectangle);
            }
        }
   }
}
