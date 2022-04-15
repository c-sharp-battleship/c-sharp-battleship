//-----------------------------------------------------------------------
// <copyright file="DragDropWindow.xaml.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship.GUIComponents
{
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

    /// <summary>
    /// Interaction logic for DragDropWindow.xaml
    /// </summary>
    public partial class DragDropWindow : Window
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="DragDropWindow" /> class.
        /// </summary>
        public DragDropWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Performs the mouse entering to a button.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void MoveButton_MouseEnter(object sender, MouseEventArgs e)
        {
            CustomButton test = new CustomButton(sender);
            string sendername = Convert.ToString(e.Source.GetType().GetProperty("Name").GetValue(e.Source, null));
            MessageBox.Show(sendername);

            Button getter = new Button();
            getter.Name = sendername;
             foreach (Button backsquare in MainGrid.Children)
             {
               if (backsquare.Name == getter.Name)
               {
               }
             }
        }

        /// <summary>
        /// Performs the drop of the main grid.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void MainGrid_Drop(object sender, DragEventArgs e)
        {
            Point myposition = Mouse.GetPosition(MainGrid);
            myposition.X = Mouse.GetPosition(MainGrid).X;
            myposition.Y = Mouse.GetPosition(MainGrid).Y;
        }
    }
}
