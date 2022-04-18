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
    /// Interaction logic for SetWindow.xaml
    /// </summary>
    public partial class SetWindow : Window
    {
        public SetWindow()
        {
            InitializeComponent();
        }
        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Say Something to the user
        /// </summary>
        public void Say(string Say)
        {
            MessageBox.Show(Say, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void CanvaCreate_Click(object sender, RoutedEventArgs e)
        {
            double boardWfixsize = 1165.8;//13.8 offset from 1152

            PlayBoard mycanva = new PlayBoard();
            mycanva.Width = boardWfixsize;
            mycanva.Height = 614.4;

            Canvas myParentCanvas = new Canvas();
            myParentCanvas.Width = boardWfixsize;
            myParentCanvas.Height = 614.4;
  
            ListBox listBox = new ListBox();
            double Gridsquareset = 19.2;

            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = Gridsquareset * 8;
            myRectangle.Height = Gridsquareset * 4;
            myRectangle.Fill = Brushes.Red;
            Canvas.SetTop(myRectangle, 200);
            Canvas.SetLeft(myRectangle, 200);
            myRectangle.MouseMove += new MouseEventHandler(myRectangle_Mousemove);

            void myRectangle_Mousemove(object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point GrabPos = e.GetPosition(myParentCanvas);
                    Canvas.SetTop(myRectangle, GrabPos.Y);
                    Canvas.SetLeft(myRectangle, GrabPos.X);
                    DragDrop.DoDragDrop(myRectangle, new DataObject(myRectangle), DragDropEffects.Move);
                }
            }


            ///Left Grid
            int Reverse = 30;
            for (int col = 0; col < 30; col++)
            {
                for (int row = 0; row < 30; row++) //Rows Button loader 
                {
                    CustomButton myButton = new CustomButton(Reverse + ((row + 1) * 0.001), 1, Reverse + ((row + 1) * 0.1).ToString());
                    myButton.Content = Reverse + ((row + 1) * 0.001).ToString();
                    myButton.Width = Gridsquareset;
                    Canvas.SetTop(myButton, row * Gridsquareset);
                    Canvas.SetLeft(myButton, col * Gridsquareset);
                    myButton.Left_Comp_ParentLeft = col * Gridsquareset;
                    myButton.Top_Comp_ParentTop = row * Gridsquareset;
                    myParentCanvas.Children.Add(myButton);//Add This button to my grid location

                    myButton.DragOver += new DragEventHandler(Onbuttondragover);

                    void Onbuttondragover(object sender, DragEventArgs e)
                    {
                        Point GrabPos = e.GetPosition(myParentCanvas);
                        Canvas.SetTop(myRectangle, myButton.Top_To_ParentTop);
                        Canvas.SetLeft(myRectangle, myButton.Left_Comp_ParentLeft);
                    }
                }
                Reverse--;
            }
            ///Right Grid
            double Leftoffset = Gridsquareset * 30;
            for (int col = 0; col < 30; col++)
            {
                for (int row = 0; row < 30; row++) //Rows Button loader 
                {
                    CustomButton myButton = new CustomButton(col + 1 + ((row + 1) * 0.001), 2, Reverse + ((row + 1) * 0.1).ToString());
                    myButton.Content = col + 1 + ((row + 1) * 0.001).ToString();
                    myButton.Width = Gridsquareset;
                    Canvas.SetTop(myButton, row * Gridsquareset);
                    Canvas.SetLeft(myButton, col * Gridsquareset + Leftoffset);
                    myButton.Left_Comp_ParentLeft = col * Gridsquareset + Leftoffset;
                    myButton.Top_Comp_ParentTop = row * Gridsquareset;
                    myParentCanvas.Children.Add(myButton);//Add This button to my grid location
                }
            }
            ///////////////////Grid transparent///////////////////////////////////////////
            ////////////insert grid here

            myParentCanvas.Children.Add(myRectangle);
            mycanva.Content = myParentCanvas;
            mycanva.Show();
        }
    }
}
