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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        public GameWindow() : base()
        {
            this.InitializeComponent();
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
            Logger.Information("The Destroyer Has Been Deployed");
        }

        private void SubmarineDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Information("The Submarine Has Been Deployed");
        }

        private void CruiserDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Information("The Cruiser Has Been Deployed");
        }

        private void BattleshipDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Information("The Battleship Has Been Deployed");
        }

        private void CarrierDeploymentButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Information("The Carrier Has Been Deployed");
        }
    }
}
