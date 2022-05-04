//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
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
        /// <param name="sender">The object that initiated the event.</param>
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
                if (this.easyAIRadioButton1.IsChecked == true)
                {
                    this.gameScreen = new GameWindow(StatusCodes.GameType.PLAYER_TO_COMPUTER);
                    this.gameScreen.ComputerPlayerDifficulty1 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_EASY;
                    this.gameScreen.Show();
                }
                else if (this.hardAIRadioButton1.IsChecked == true)
                {
                    this.gameScreen = new GameWindow(StatusCodes.GameType.PLAYER_TO_COMPUTER);
                    this.gameScreen.ComputerPlayerDifficulty1 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_HARD;
                    this.gameScreen.Show();
                }
                else
                {
                    Logger.Error("Please Select an AI difficulty for Computer Player!");
                }
            }
            else if (this.computerToComputerRadioButton.IsChecked == true)
            {
                if (this.easyAIRadioButton1.IsChecked == true)
                {
                    if (this.easyAIRadioButton2.IsChecked == true)
                    {
                        this.gameScreen = new GameWindow(StatusCodes.GameType.COMPUTER_TO_COMPUTER);
                        this.gameScreen.ComputerPlayerDifficulty1 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_EASY;
                        this.gameScreen.ComputerPlayerDifficulty2 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_EASY;
                        this.gameScreen.Show();
                    }
                    else if (this.hardAIRadioButton2.IsChecked == true)
                    {
                        this.gameScreen = new GameWindow(StatusCodes.GameType.COMPUTER_TO_COMPUTER);
                        this.gameScreen.ComputerPlayerDifficulty1 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_EASY;
                        this.gameScreen.ComputerPlayerDifficulty2 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_HARD;
                        this.gameScreen.Show();
                    }
                    else
                    {
                        Logger.Error("Please Select an AI Difficulty for Computer Player 2!");
                    }
                }
                else if (this.hardAIRadioButton1.IsChecked == true)
                {
                    if (this.easyAIRadioButton2.IsChecked == true)
                    {
                        this.gameScreen = new GameWindow(StatusCodes.GameType.COMPUTER_TO_COMPUTER);
                        this.gameScreen.ComputerPlayerDifficulty1 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_HARD;
                        this.gameScreen.ComputerPlayerDifficulty2 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_EASY;
                        this.gameScreen.Show();
                    }
                    else if (this.hardAIRadioButton2.IsChecked == true)
                    {
                        this.gameScreen = new GameWindow(StatusCodes.GameType.COMPUTER_TO_COMPUTER);
                        this.gameScreen.ComputerPlayerDifficulty1 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_HARD;
                        this.gameScreen.ComputerPlayerDifficulty2 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_HARD;
                        this.gameScreen.Show();
                    }
                    else
                    {
                        Logger.Error("Please Select an AI Difficulty for Computer Player 2!");
                    }
                }
                else
                {
                    Logger.Error("Please Select an AI difficulty for Computer Player 1!");
                }
            }
            else
            {
                Logger.Error("Please Select a Game Type!");
            }
        }

        /// <summary>
        /// Set a about button click.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
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
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method to update the radio buttons.
        /// </summary>
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

        /// <summary>
        /// Method to change the whether or not the computer players options are available.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The parameters to be passed to the event.</param>
        private void PlayerToPlayerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateRadioButtonOptions();
        }

        /// <summary>
        /// Method to change the whether or not the computer players options are available.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The parameters to be passed to the event.</param>
        private void PlayerToComputerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateRadioButtonOptions();
        }

        /// <summary>
        /// Method to change the whether or not the computer players options are available.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The parameters to be passed to the event.</param>
        private void ComputerToComputerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateRadioButtonOptions();
        }

        /// <summary>
        /// Method to change the whether or not the computer players options are available.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The parameters to be passed to the event.</param>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.UpdateRadioButtonOptions();
        }
    }
}