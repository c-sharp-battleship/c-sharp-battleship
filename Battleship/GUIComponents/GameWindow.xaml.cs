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

namespace Battleship.GUIComponents
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Game currentGame;

        public GameWindow() : base()
        {
            this.InitializeComponent();

            this.currentGame = new Game();
        }

        public GameWindow(string title) : base()
        {
            this.InitializeComponent();
            this.Title = title;
        }

        public GameWindow(int width, int height, string title) : base()
        {
            this.InitializeComponent();
            this.Title = title;

            this.Player1Board.Width = width;
            this.Player1Board.Height = height;
        }

        // Game Control Click Events
        private void NextPlayerTurnButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Information("It's the next player's turn!");
        }

        private void RestGameButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Information("The Game Has Been Reset");
        }

        private void EndGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Environment.Exit(0);
        }

        // Ship Placement Button Click Events
        private void DestroyerDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Destroyer Has Been Deployed");
            this.Player1DefenseGrid.deployDestroyerShip();
            this.DestroyerDeploymentButton.IsEnabled = false;
        }

        private void SubmarineDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Submarine Has Been Deployed");
            this.Player1DefenseGrid.deploySubmarineShip();
            this.SubmarineDeploymentButton.IsEnabled = false;
        }

        private void CruiserDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Cruiser Has Been Deployed");
            this.Player1DefenseGrid.deployCruiserShip();
            this.CruiserDeploymentButton.IsEnabled = false;
        }

        private void BattleshipDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Battleship Has Been Deployed");
            this.Player1DefenseGrid.deployBattleshipShip();
            this.BattleshipDeploymentButton.IsEnabled = false;
        }

        private void CarrierDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleInformation("The Carrier Has Been Deployed");
            this.Player1DefenseGrid.deployCarrierShip();
            this.CarrierDeploymentButton.IsEnabled = false;
        }
    }
}
