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
        DefenseGrid _DefenseGrid;
        AttackGrid _AttackGrid;

        public GameWindow()
        {
            this.InitializeComponent();

            this._AttackGrid = new AttackGrid(this.Player1Board.Width / 2, this.Player1Board.Height, 19.2);
            this._DefenseGrid = new DefenseGrid(this.Player1Board.Width / 2, this.Player1Board.Height, 19.2);

            this.Player1Board.Children.Add(this._AttackGrid);
            this.Player1Board.Children.Add(this._DefenseGrid);

            // MainCanvas mainCanvas = new MainCanvas(800, 600);
            // this.Player1Board.Content = mainCanvas;
        }

        public GameWindow(int width, int height, string title)
        {
            this.InitializeComponent();
            this.Title = title;

            this._AttackGrid = new AttackGrid(this.Player1Board.Width / 2, this.Player1Board.Height, 19.2);
            // this._DefenseGrid = new DefenseGrid(this.Player1Board.Width / 2, this.Player1Board.Height, 19.2);

            this.Player1Board.Children.Add(this._AttackGrid);
            // this.Player1Board.Children.Add(this._DefenseGrid);
            

            // MainCanvas mainCanvas = new MainCanvas(width, height);
            // this.Content = mainCanvas;
        }

        private void EndGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Environment.Exit(0);
        }

        private void RestGameButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Information("The Game Has Been Reset");
        }

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
