﻿//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
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
        /// The game screen.
        /// </summary>
        private GameWindow gameScreen;

        /// <summary>
        /// The about screen.
        /// </summary>
        private AboutWindow aboutScreen;

        /// <summary>
        /// The project info screen.
        /// </summary>
        private UMLstructure projectInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
           this.InitializeComponent();
        }

        /// <summary>
        /// Set a start game button click.
        /// </summary>
        /// <param name="sender">The object that initiated the event</param>
        /// <param name="e">The event arguments for the event.</param>
        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.playerToPlayerRadioButton.IsChecked == true)
            {
                this.gameScreen = new GameWindow(StatusCodes.GameType.PLAYER_TO_PLAYER);
                this.gameScreen.Show();
            }
            else if (this.playerToComputerRadioButton.IsChecked == true)
            {
                this.gameScreen = new GameWindow(StatusCodes.GameType.PLAYER_TO_COMPUTER);
                this.gameScreen.Show();
            }
            else if (this.computerToComputerRadioButton.IsChecked == true)
            {
                this.gameScreen = new GameWindow(StatusCodes.GameType.COMPUTER_TO_COMPUTER);
                this.gameScreen.Show();
            }
            else
            {
                Logger.Error("Please Select a Game Type!");
            }
        }

        /// <summary>
        /// Set a about button click.
        /// </summary>
        /// <param name="sender">The object that initiated the event</param>
        /// <param name="e">The event arguments for the event.</param>
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            this.aboutScreen = new AboutWindow();
            this.projectInfo = new UMLstructure();

            this.aboutScreen.Show();
            this.projectInfo.Show();
        }

        /// <summary>
        /// Set a quit button click.
        /// </summary>
        /// <param name="sender">The object that initiated the event</param>
        /// <param name="e">The event arguments for the event.</param>
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateRadioButtonOptions()
        {
            if (this.playerToComputerRadioButton.IsChecked == true)
            {
                this.easyAIRadioButton1.IsEnabled = true;
                this.hardAIRadioButton1.IsEnabled = true;

                this.easyAIRadioButton2.IsEnabled = false;
                this.hardAIRadioButton2.IsEnabled = false;
            }
            else if (this.computerToComputerRadioButton.IsChecked == true)
            {
                this.easyAIRadioButton1.IsEnabled = true;
                this.hardAIRadioButton1.IsEnabled = true;

                this.easyAIRadioButton2.IsEnabled = true;
                this.hardAIRadioButton2.IsEnabled = true;
            }
            else
            {
                this.easyAIRadioButton1.IsEnabled = false;
                this.hardAIRadioButton1.IsEnabled = false;

                this.easyAIRadioButton2.IsEnabled = false;
                this.hardAIRadioButton2.IsEnabled = false;
            }
        }

        private void playerToPlayerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateRadioButtonOptions();
        }

        private void playerToComputerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateRadioButtonOptions();
        }

        private void computerToComputerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateRadioButtonOptions();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.UpdateRadioButtonOptions();
        }
    }
}