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

namespace Battleship
{
    /// <summary>
    /// Interaction logic for DragDropWindow.xaml
    /// </summary>
    public partial class DragDropWindow : Window
    {
        public DragDropWindow()
        {
            InitializeComponent();
        }


        private void MoveButton_MouseEnter(object sender, MouseEventArgs e)
        {
            CustomButton test = new CustomButton(sender);
            string Sendername = Convert.ToString(e.Source.GetType().GetProperty("Name").GetValue(e.Source, null));
            MessageBox.Show(Sendername);

            Button getter = new Button();
            getter.Name = Sendername;
             foreach (Button backsquare in MainGrid.Children)
             {
               if(backsquare.Name == getter.Name)
               {
               }
             }

        }

        private void MainGrid_Drop(object sender, DragEventArgs e)
        {
            Point myposition = Mouse.GetPosition(MainGrid);
            myposition.X = Mouse.GetPosition(MainGrid).X;
            myposition.Y = Mouse.GetPosition(MainGrid).Y;
        }
    }
}
