//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="David Fedchuk, Gerson Eliu Sorto Flores, Lincoln Kaszynski, Sanaaia Okhlopkova, and Samuel Mace">
//     MIT License, 2022 (https://mit-license.org).
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System.Collections.Generic;
    using System.IO;
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
        /// The advanced options screen.
        /// </summary>
        private AdvancedOptionsWindow advancedOptionsScreen;

        /// <summary>
        /// The advanced options.
        /// </summary>
        private AdvancedOptions advancedOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
           this.InitializeComponent();

           this.Player1NameTextBox.IsEnabled = false;
           this.Player2NameTextBox.IsEnabled = false;

           string pathList = "SavedGamesList.txt";
           if (File.Exists(pathList))
           {
               using (StreamReader sr = File.OpenText(pathList))
               {
                   while (sr.Peek() != -1)
                   {
                       this.SavedGamesList.Items.Add(sr.ReadLine());
                   }
               }
           }

           this.advancedOptions = new AdvancedOptions();
           this.AdvancedOptionsButton.IsEnabled = false;
        }

        /// <summary>
        /// Method to add an item to the <see cref="SavedGamesList"/>.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        public void AddItem(string fileName)
        {
            this.SavedGamesList.Items.Add(fileName);
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
                if (this.Player1NameTextBox.Text == string.Empty)
                {
                    Logger.Information("Please enter the player 1 name!");
                }
                else if (this.Player2NameTextBox.Text == string.Empty)
                {
                    Logger.Information("Please enter the player 2 name!");
                }
                else
                {
                    this.gameScreen = new GameWindow(StatusCodes.GameType.PLAYER_TO_PLAYER, ref this.advancedOptions);
                    this.gameScreen.Player1Name = this.Player1NameTextBox.Text;
                    this.gameScreen.Player2Name = this.Player2NameTextBox.Text;
                    this.gameScreen.Show();
                }
            }
            else if (this.playerToComputerRadioButton.IsChecked == true)
            {
                if (this.Player1NameTextBox.Text == string.Empty)
                {
                    Logger.Information("Please enter the player 1 name!");
                }
                else
                {
                    if (this.easyAIRadioButton1.IsChecked == true)
                    {
                        this.gameScreen = new GameWindow(StatusCodes.GameType.PLAYER_TO_COMPUTER);
                        this.gameScreen.ComputerPlayerDifficulty2 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_EASY;
                        this.gameScreen.Player1Name = this.Player1NameTextBox.Text;
                        this.gameScreen.Show();
                    }
                    else if (this.hardAIRadioButton1.IsChecked == true)
                    {
                        this.gameScreen = new GameWindow(StatusCodes.GameType.PLAYER_TO_COMPUTER);
                        this.gameScreen.ComputerPlayerDifficulty2 = StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_HARD;
                        this.gameScreen.Player1Name = this.Player1NameTextBox.Text;
                        this.gameScreen.Show();
                    }
                    else
                    {
                        Logger.Error("Please Select an AI difficulty for Computer Player!");
                    }
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

            this.aboutScreen.Show();
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
            this.Player1NameTextBox.IsEnabled = true;
            this.Player2NameTextBox.IsEnabled = true;
            this.AdvancedOptionsButton.IsEnabled = true;
            Logger.Information("Advanced options available. Please click \"Advanced Options\" button for more information.");
        }

        /// <summary>
        /// Method to change the whether or not the computer players options are available.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The parameters to be passed to the event.</param>
        private void PlayerToComputerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateRadioButtonOptions();
            this.Player1NameTextBox.IsEnabled = true;
            this.Player2NameTextBox.IsEnabled = false;
            this.AdvancedOptionsButton.IsEnabled = false;
        }

        /// <summary>
        /// Method to change the whether or not the computer players options are available.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The parameters to be passed to the event.</param>
        private void ComputerToComputerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateRadioButtonOptions();
            this.Player1NameTextBox.IsEnabled = false;
            this.Player2NameTextBox.IsEnabled = false;
            this.AdvancedOptionsButton.IsEnabled = false;
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

        /// <summary>
        /// Click event to load a game from the <see cref="SavedGamesList"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The parameters to be passed to the event.</param>
        private void BtnLoadGame_Click(object sender, RoutedEventArgs e)
        {
            if (this.SavedGamesList.SelectedItem != null)
            {
                this.gameScreen = new GameWindow(this.SavedGamesList.SelectedItem.ToString());
                this.gameScreen.Show();
            }
            else
            {
                Logger.Information("Please select the file to load!");
            }
        }

        /// <summary>
        /// Click event to delete a game from the <see cref="SavedGamesList"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The parameters to be passed to the event.</param>
        private void BtnDeleteGame_Click(object sender, RoutedEventArgs e)
        {
            if (this.SavedGamesList.SelectedItem != null)
            {
                string path = this.SavedGamesList.SelectedItem.ToString();
                if (File.Exists(path))
                {
                    File.Delete(path);
                    this.SavedGamesList.Items.Remove(this.SavedGamesList.SelectedItem);
                    string pathList = "SavedGamesList.txt";
                    if (File.Exists(pathList))
                    {
                        string[] lines = File.ReadAllLines(pathList);
                        File.Delete(pathList);
                        using (StreamWriter sr = File.CreateText(pathList))
                        {
                            for (int i = lines.Length - 1; i >= 0; i--)
                            {
                                if (lines[i] != path)
                                {
                                    sr.WriteLine(lines[i]);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Logger.Information("Please select the file to delete!");
            }
        }

        /// <summary>
        /// Click event for the <see cref="AdvancedOptionsButton"/>.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void AdvancedOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            this.advancedOptionsScreen = new AdvancedOptionsWindow(ref this.advancedOptions);
            this.advancedOptionsScreen.Show();
        }
    }
}