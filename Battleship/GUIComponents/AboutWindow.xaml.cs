//-----------------------------------------------------------------------
// <copyright file="AboutWindow.xaml.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
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
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutWindow" /> class.
        /// </summary>
        public AboutWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The click event to close the window.
        /// </summary>
        /// <param name="sender">The object which invoked the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
