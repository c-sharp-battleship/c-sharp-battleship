//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship.GUIComponents
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
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The click event that launches a new instance of the <see cref="GameWindow"/> class.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow("Battleship: A Game of Adventure and Conquest");
            gameWindow.Show();
        }

        /// <summary>
        /// The click event that launches a new instance of the <see cref="AboutWindow"/> class.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        /// <summary>
        /// The click event that closes the <see cref="MainWindow"/> and exits the <see cref="App"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
}