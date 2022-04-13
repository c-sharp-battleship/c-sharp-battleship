//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Performs the appearing of the start game window.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            SetWindow setWindow = new SetWindow();
            setWindow.Show();
        }

        /// <summary>
        /// Performs the appearing of the about window.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        /// <summary>
        /// Performs the closing of the window.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
