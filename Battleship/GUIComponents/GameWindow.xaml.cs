//-----------------------------------------------------------------------
// <copyright file="GameWindow.xaml.cs" company="Battleship Coding Group">
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

    using Battleship.CoreComponents;

    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        /// <summary>
        /// The object that represents the current <see cref="Game"/>.
        /// </summary>
        private Game currentGame;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow" /> class.
        /// </summary>
        public GameWindow() : base()
        {
            this.InitializeComponent();

            this.currentGame = new Game();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow" /> class.
        /// </summary>
        /// <param name="title">The title for the <see cref="GameWindow"/>.</param>
        public GameWindow(string title) : base()
        {
            this.InitializeComponent();
            this.Title = title;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow"/> class.
        /// </summary>
        /// <param name="width">The width of the <see cref="GameWindow"/>.</param>
        /// <param name="height">The height of the <see cref="GameWindow"/>.</param>
        /// <param name="title">The title for the <see cref="GameWindow"/>.</param>
        public GameWindow(int width, int height, string title) : base()
        {
            this.InitializeComponent();
            this.Title = title;

            this.Player1Board.Width = width;
            this.Player1Board.Height = height;
        }

        /// <summary>
        /// The click event that switches the current <see cref="Game"/>'s turn.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void NextPlayerTurnButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("It's the next player's turn!");

            if (this.Player1Board.IsVisible == true)
            {
                this.Player1Board.Visibility = Visibility.Hidden;
                this.Player2Board.Visibility = Visibility.Visible;
            }
            else
            {
                this.Player1Board.Visibility = Visibility.Visible;
                this.Player2Board.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// The click event that resets the current <see cref="Game"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void RestGameButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Game Has Been Reset");
        }

        /// <summary>
        /// The click event that ends the current <see cref="Game"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void EndGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Environment.Exit(0);
        }

        /// <summary>
        /// The click event that deploys the Destroyer <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void Player1DestroyerDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Destroyer Has Been Deployed");
            this.Player1DefenseGrid.DeployDestroyerShip();
            this.Player1DestroyerDeploymentButton.IsEnabled = false;
        }

        /// <summary>
        /// The click event that deploys the Submarine <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void Player1SubmarineDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Submarine Has Been Deployed");
            this.Player1DefenseGrid.DeploySubmarineShip();
            this.Player1SubmarineDeploymentButton.IsEnabled = false;
        }

        /// <summary>
        /// The click event that deploys the Cruiser <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void Player1CruiserDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Cruiser Has Been Deployed");
            this.Player1DefenseGrid.DeployCruiserShip();
            this.Player1CruiserDeploymentButton.IsEnabled = false;
        }

        /// <summary>
        /// The click event that deploys the Battleship <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void Player1BattleshipDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Battleship Has Been Deployed");
            this.Player1DefenseGrid.DeployBattleshipShip();
            this.Player1BattleshipDeploymentButton.IsEnabled = false;
        }

        /// <summary>
        /// The click event that deploys the Carrier <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void Player1CarrierDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Carrier Has Been Deployed");
            this.Player1DefenseGrid.DeployCarrierShip();
            this.Player1CarrierDeploymentButton.IsEnabled = false;
        }

        /// <summary>
        /// The click event that deploys the Destroyer <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void Player2DestroyerDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Destroyer Has Been Deployed");
            this.Player2DefenseGrid.DeployDestroyerShip();
            this.Player2DestroyerDeploymentButton.IsEnabled = false;
        }

        /// <summary>
        /// The click event that deploys the Submarine <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void Player2SubmarineDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Submarine Has Been Deployed");
            this.Player2DefenseGrid.DeploySubmarineShip();
            this.Player2SubmarineDeploymentButton.IsEnabled = false;
        }

        /// <summary>
        /// The click event that deploys the Cruiser <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void Player2CruiserDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Cruiser Has Been Deployed");
            this.Player2DefenseGrid.DeployCruiserShip();
            this.Player2CruiserDeploymentButton.IsEnabled = false;
        }

        /// <summary>
        /// The click event that deploys the Battleship <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void Player2BattleshipDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Battleship Has Been Deployed");
            this.Player2DefenseGrid.DeployBattleshipShip();
            this.Player2BattleshipDeploymentButton.IsEnabled = false;
        }

        /// <summary>
        /// The click event that deploys the Carrier <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void Player2CarrierDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Carrier Has Been Deployed");
            this.Player2DefenseGrid.DeployCarrierShip();
            this.Player2CarrierDeploymentButton.IsEnabled = false;
        }
    }
}
