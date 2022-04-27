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

namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameWindow gameScreen;
        private AboutWindow aboutScreen;
        private UMLstructure projectInfo;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.playerToPlayerRadioButton.IsChecked == true)
            {
                this.gameScreen = new GameWindow(StatusCodes.GameType.PLAYER_TO_PLAYER);
                this.gameScreen.Show();
            }
            else if(this.playerToComputerRadioButton.IsChecked == true)
            {
                this.gameScreen = new GameWindow(StatusCodes.GameType.PLAYER_TO_COMPUTER);
                this.gameScreen.Show();
            }
            else if(this.computerToComputerRadioButton.IsChecked == true)
            {
                this.gameScreen = new GameWindow(StatusCodes.GameType.COMPUTER_TO_COMPUTER);
                this.gameScreen.Show();
            }
            else
            {
                Logger.Error("Please Select a Game Type!");
            }
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            this.aboutScreen = new AboutWindow();
            this.projectInfo = new UMLstructure();

            this.aboutScreen.Show();
            this.projectInfo.Show();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}