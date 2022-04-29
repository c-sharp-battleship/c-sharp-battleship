﻿//-----------------------------------------------------------------------
// <copyright file="GameWindow.xaml.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public partial class GameWindow : Window
    {
        /// <summary>
        /// The cell size.
        /// </summary>
        public double Cellsize = 25;

        /// <summary>
        /// The number of rows.
        /// </summary>
        public int RowRep = 10;

        /// <summary>
        /// The list of player cell grids.
        /// </summary>
        public List<GridCell> PlayersCellRecords;

        /// <summary>
        /// The game type.
        /// </summary>
        private StatusCodes.GameType gameType;

        /// <summary>
        /// The player 1 screen.
        /// </summary>
        private bool screenPlayerOne = true;

        /// <summary>
        /// The player 1.
        /// </summary>
        private Player player1;

        /// <summary>
        /// The player 2.
        /// </summary>
        private Player player2;

        /// <summary>
        /// The computer player 1.
        /// </summary>
        private ComputerPlayer computerPlayer1;

        /// <summary>
        /// The computer player 2.
        /// </summary>
        private ComputerPlayer computerPlayer2;

        /// <summary>
        /// The player 1 window.
        /// </summary>
        private Canvas playerWindow1;

        /// <summary>
        /// The player 2 window.
        /// </summary>
        private Canvas playerWindow2;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow" /> class.
        /// </summary>
        /// <param name="gameType"> This is the game type.</param>
        public GameWindow(StatusCodes.GameType gameType)
        {
            this.PlayersCellRecords = new List<GridCell>();

            this.InitializeComponent();

            this.gameType = gameType;

            switch (gameType)
            {
                case StatusCodes.GameType.PLAYER_TO_PLAYER:
                    this.Loaded += this.StartPlayerToPlayerGame;
                    break;
                case StatusCodes.GameType.PLAYER_TO_COMPUTER:
                    this.Loaded += this.StartPlayerToComputerGame;
                    break;
                case StatusCodes.GameType.COMPUTER_TO_COMPUTER:
                    this.Loaded += this.StartComputerToComputerGame;
                    break;
                default:
                    this.Loaded += this.StartGame;
                    break;
            }
        }

        /// <summary>
        ///  Gets a value indicating whether screen player1 is visible or not
        /// </summary>
        public bool Switch
        {
            get { return this.screenPlayerOne; }
        }

        /// <summary>
        /// Start a player to player game.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        public void StartPlayerToPlayerGame(object sender, EventArgs e)
        {
            this.StartGame(sender, e);
        }

        /// <summary>
        /// Start a player to computer game.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        public void StartPlayerToComputerGame(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Start a computer to computer game.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        public void StartComputerToComputerGame(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Start the game.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        public void StartGame(object sender, EventArgs e)
        {
            // start player one label visible
            PlayerOnelabel.Visibility = Visibility.Visible;
            PlayerTwolabel.Visibility = Visibility.Hidden;
            AttackBtn.IsEnabled = false;

            // Create Players with their cells and their ships and grids colors
            // 1 = Black,2=dark blue,3=magenta,4=lightseagreen,5=purple,6=white,standard cadet blue
            this.player1 = new Player(1, "PlayerOne", this.Cellsize, this.RowRep, 1, 3);
            this.player2 = new Player(2, "PlayerOne", this.Cellsize, this.RowRep, 3, 6);

            // Create two Canvas to place the player elements on them 
            this.playerWindow1 = new Canvas();
            this.playerWindow1.HorizontalAlignment = HorizontalAlignment.Center;
            this.playerWindow1.VerticalAlignment = VerticalAlignment.Center;
            this.playerWindow1.Uid = "Player1Canvas";
            this.playerWindow1.Width = (this.Cellsize * this.RowRep) * 2;
            this.playerWindow1.Visibility = Visibility.Visible;

            this.playerWindow2 = new Canvas();
            this.playerWindow2.HorizontalAlignment = HorizontalAlignment.Center;
            this.playerWindow2.VerticalAlignment = VerticalAlignment.Center;
            this.playerWindow2.Uid = "Player2Canvas";
            this.playerWindow2.Width = (this.Cellsize * this.RowRep) * 2;
            this.playerWindow2.Visibility = Visibility.Hidden;


            DeclarePlayerGrid(this.player1, this.player2, this.PlayersCellRecords, this.playerWindow1, this.Cellsize);
            DeclarePlayerShips(this.player1, this.playerWindow1, this.Cellsize);

            DeclarePlayerGrid(this.player2, this.player1, this.PlayersCellRecords, this.playerWindow2, this.Cellsize);
            DeclarePlayerShips(this.player2, this.playerWindow2, this.Cellsize);

            // load both canvas to this window grid
            this.Maingrid.Children.Add(this.playerWindow1);
            this.Maingrid.Children.Add(this.playerWindow2);

            this.Show();
        }

        private void DeclarePlayerGrid(Player p_currentPlayer, Player p_otherPlayer, List<GridCell> p_playersCellRecords, Canvas p_currentPlayerWindow, double p_cellsize)
        {
            foreach (GridCell currentPlayerOffenseButton in p_currentPlayer.Playergridsquarecollection)
            {
                p_playersCellRecords.Add(currentPlayerOffenseButton);

                // add a click event for all cells in Player 1 grid only if the button is attack type
                if (currentPlayerOffenseButton.OffenseButton == true)
                {
                    // add click event
                    currentPlayerOffenseButton.Click += new RoutedEventHandler(delegate(object sender, RoutedEventArgs e)
                    {
                        // go check the list of buttons for player two and change the status for them
                        foreach (GridCell otherPlayerDefenseButton in p_otherPlayer.Playergridsquarecollection)
                        {
                            // turn off buttons on the enemy grid(player two left side)only if it is a defense button
                            if (currentPlayerOffenseButton.Uid == otherPlayerDefenseButton.Uid && otherPlayerDefenseButton.OffenseButton == false)
                            {
                                // make changes to player two grid
                                otherPlayerDefenseButton.Background = Brushes.Red;
                                otherPlayerDefenseButton.Content = "X";
                                otherPlayerDefenseButton.Stricked = 1;
                                otherPlayerDefenseButton.AllowDrop = false;

                                // make changes to player one grid
                                currentPlayerOffenseButton.Visibility = Visibility.Hidden;
                            }
                        }

                        Coordinate attackedGridSpace = new Coordinate((short)currentPlayerOffenseButton.ColNum, (short)currentPlayerOffenseButton.RowNum);

                        Logger.ConsoleInformation("Row Number: " + currentPlayerOffenseButton.RowNum);
                        Logger.ConsoleInformation("Column Number: " + currentPlayerOffenseButton.ColNum);

                        foreach (Ship testShip in p_currentPlayer.Playershipcollection)
                        {
                            AttackCoordinate tempCoordainte = testShip.AttackGridSpace(attackedGridSpace);
                        }

                        // Swicth windows between players 
                        this.SwitchPlayerWindows();
                    });
                }
                else
                {
                    // add the drag over event for when ships are dragged over the cells only if the cell is deffense type
                    // Create a method when an object is drag over this left button
                    currentPlayerOffenseButton.DragOver += new DragEventHandler(delegate (object sender, DragEventArgs e)
                    {
                        // find the sender uid extracting the date of the event
                        string myWarshipUid = e.Data.GetData(DataFormats.StringFormat).ToString();

                        // iterate thru the collection of ships to find the sender element with matching uid
                        foreach (Ship ship in p_currentPlayer.Playershipcollection)
                        {
                            // if the sender element uid matches then this is my element, then move it with the mouse
                            if (myWarshipUid == ship.Uid)
                            {
                                Point grabPos = e.GetPosition(p_currentPlayerWindow); // find the position of the mouse compared to the canvas for player one
                                double shipMaxX = (p_currentPlayerWindow.Width / 2) - ship.Width + p_cellsize;
                                double shipMaxY = (p_currentPlayerWindow.Width / 2) - ship.Height + p_cellsize;
                                if (grabPos.X < shipMaxX && grabPos.Y < shipMaxY)
                                {
                                    Canvas.SetTop(ship, currentPlayerOffenseButton.Top_Comp_ParentTop);
                                    ship.Top_Comp_ParentTop = currentPlayerOffenseButton.Top_Comp_ParentTop;
                                    Canvas.SetLeft(ship, currentPlayerOffenseButton.Left_Comp_ParentLeft);
                                    ship.Left_Comp_ParentLeft = currentPlayerOffenseButton.Left_Comp_ParentLeft;
                                    Coordinate shipStartCoords = this.ConvertCanvasCoordinatesToGridCoordinates(grabPos.X, grabPos.Y);
                                    Coordinate shipEndCoords = this.ConvertCanvasCoordinatesToGridCoordinates(grabPos.X, grabPos.Y);

                                    if (ship.HDirection == true)
                                    {
                                        shipEndCoords.XCoordinate += (short)((ship.Width / p_cellsize) - 1);
                                    }
                                    else if (ship.HDirection == false)
                                    {
                                        shipEndCoords.YCoordinate += (short)((ship.Height / p_cellsize) - 1);
                                    }

                                    this.UpdateShipCoords(ship, shipStartCoords, shipEndCoords);
                                }
                            }
                        }
                    });
                }

                //// Add player 1 cells to the window grid
                p_currentPlayerWindow.Children.Add(currentPlayerOffenseButton);
            }
        }

        private void DeclarePlayerShips(Player p_currentPlayer, Canvas p_currentPlayerWindow, double p_cellsize)
        {
            foreach (Ship ship_1 in p_currentPlayer.Playershipcollection)
            {
                // create a move move event for player 1 ships to attacch the rectangle to the mouse
                ship_1.MouseMove += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
                {
                    if (p_currentPlayer.isLocked == false)
                    {
                        if (e.LeftButton == MouseButtonState.Pressed)
                        {
                            string objectUniqueID = ship_1.Uid;
                            Point grabPos = e.GetPosition(ship_1);
                            Canvas.SetTop(ship_1, grabPos.Y);
                            Canvas.SetLeft(ship_1, grabPos.X);
                            DragDrop.DoDragDrop(ship_1, objectUniqueID, DragDropEffects.Move);
                        }
                    }
                });

                ship_1.MouseRightButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs e)
                {
                    if (p_currentPlayer.isLocked == false)
                    {
                        if (ship_1.HDirection == true)
                        {
                            double shipMaxY = (p_currentPlayerWindow.Width / 2) - (this.Cellsize * 2);
                            double shipMaxX = p_currentPlayerWindow.Width / 2;
                            bool canRotateShip = true;
                            // check the borders
                            if (ship_1.Top_Comp_ParentTop < shipMaxY && ship_1.Left_Comp_ParentLeft < shipMaxX)
                            {
                                // the end coordinates of the ship after rotation
                                Coordinate shipAfterRotateEndCoords =
                                    new Coordinate(ship_1.ShipStartCoords.XCoordinate,
                                        (short)(ship_1.ShipStartCoords.YCoordinate + ship_1.Length - 1));
                                // loop through the list of ships
                                foreach (Ship ship_2_neighbor in player2.Playershipcollection)
                                {
                                    // check that the ship is not the same ship and it creates a cross with other ships
                                    if (ship_1.ShipStartCoords != ship_2_neighbor.ShipStartCoords
                                        && ship_1.ShipStartCoords.YCoordinate <= ship_2_neighbor.ShipEndCoords.YCoordinate
                                        && shipAfterRotateEndCoords.YCoordinate >= ship_2_neighbor.ShipStartCoords.YCoordinate
                                        && shipAfterRotateEndCoords.XCoordinate >= ship_2_neighbor.ShipStartCoords.XCoordinate
                                        && shipAfterRotateEndCoords.XCoordinate <= ship_2_neighbor.ShipEndCoords.XCoordinate)
                                    {
                                        // if yes, doesn't allow to rotate
                                        canRotateShip = false;
                                        break;
                                    }
                                }

                                if (canRotateShip)
                                {
                                    ship_1.RotateShip(true);
                                }
                            }
                        }
                        else
                        {
                            double shipMaxY = p_currentPlayerWindow.Width / 2;
                            double shipMaxX = (p_currentPlayerWindow.Width / 2) - (this.Cellsize * 2);
                            bool canRotateShip = true;
                            // check the borders
                            if (ship_1.Top_Comp_ParentTop < shipMaxY && ship_1.Left_Comp_ParentLeft < shipMaxX)
                            {
                                // the end coordinates of the ship after rotation
                                Coordinate shipAfterRotateEndCoords =
                                    new Coordinate((short)(ship_1.ShipStartCoords.XCoordinate + ship_1.Length - 1),
                                        ship_1.ShipStartCoords.YCoordinate);
                                // loop through the list of ships
                                foreach (Ship ship_2_neighbor in player2.Playershipcollection)
                                {
                                    // check that the ship is not the same ship and it creates a cross with other ships
                                    if (ship_1.ShipStartCoords != ship_2_neighbor.ShipStartCoords
                                        && ship_1.ShipStartCoords.XCoordinate <= ship_2_neighbor.ShipEndCoords.XCoordinate
                                        && shipAfterRotateEndCoords.XCoordinate >= ship_2_neighbor.ShipStartCoords.XCoordinate
                                        && shipAfterRotateEndCoords.YCoordinate >= ship_2_neighbor.ShipStartCoords.YCoordinate
                                        && shipAfterRotateEndCoords.YCoordinate <= ship_2_neighbor.ShipEndCoords.YCoordinate)
                                    {
                                        // if the ship creates cross with other ships, doesn't allow to rotate
                                        canRotateShip = false;
                                        break;
                                    }
                                }

                                if (canRotateShip)
                                {
                                    ship_1.RotateShip(true);
                                }
                                //Logger.ConsoleInformation("New Ship Start Coords: " + ship_2.ShipStartCoords.XCoordinate.ToString() + ", " + ship_2.ShipStartCoords.YCoordinate.ToString());
                                //Logger.ConsoleInformation("New Ship End Coords: " + ship_2.ShipEndCoords.XCoordinate.ToString() + ", " + ship_2.ShipEndCoords.YCoordinate.ToString());
                            }
                        }
                    }
                });

                // Add player 1 Ships to the window grid
                p_currentPlayerWindow.Children.Add(ship_1);
            }
        }

        /// <summary>
        /// Make the windows visible with Attack button
        /// </summary>
        public void SwitchPlayerWindows()
        {
            if (this.screenPlayerOne == true)
            {
                // change the visual to off for player 1 and turn on the vissible to player two canvas
                this.screenPlayerOne = false;
                PlayerOnelabel.Visibility = Visibility.Hidden;
                PlayerTwolabel.Visibility = Visibility.Visible;
                foreach (UIElement canvas in this.Maingrid.Children)
                {
                    if (canvas.Uid == "Player1Canvas")
                    {
                        canvas.Visibility = Visibility.Hidden;
                    }

                    if (canvas.Uid == "Player2Canvas")
                    {
                        canvas.Visibility = Visibility.Visible;
                    }
                }
                //// if the switch button has been clicked for the first time then allow player2 to move their ships
                this.SetConfirmButtonVisibility("Player2Canvas");
            }
            else
            {
                // if the screen player one entert the method in false condition
                // change the visual to on for player 1 and turn off the vissible to player two canvas
                this.screenPlayerOne = true;
                PlayerOnelabel.Visibility = Visibility.Visible;
                PlayerTwolabel.Visibility = Visibility.Hidden;

                foreach (UIElement canvas in this.Maingrid.Children)
                {
                    if (canvas.Uid == "Player1Canvas")
                    {
                        canvas.Visibility = Visibility.Visible;
                    }

                    if (canvas.Uid == "Player2Canvas")
                    {
                        canvas.Visibility = Visibility.Hidden;
                    }
                }

                this.SetConfirmButtonVisibility("Player1Canvas");
            }
        }

        /// <summary>
        /// Set a confirm button visibility.
        /// </summary>
        /// <param name="canvasUid">The id of the canvas.</param>
        private void SetConfirmButtonVisibility(string canvasUid)
        {
            if ((canvasUid == "Player1Canvas" && this.player1.isLocked == true) || (canvasUid == "Player2Canvas" && this.player2.isLocked == true))
            {
                this.Confirm_Button.IsEnabled = false;
                this.AttackBtn.IsEnabled = true;
                if (canvasUid == "Player1Canvas")
                {
                    foreach (Ship ship in this.player1.Playershipcollection)
                    {
                        int startColumn = (int)ship.ShipStartCoords.XCoordinate - 1;
                        int startRow = (int)ship.ShipStartCoords.YCoordinate - 1;
                        int endColumn = (int)ship.ShipEndCoords.XCoordinate - 1;
                        int endRow = (int)ship.ShipEndCoords.YCoordinate - 1;
                        string letter = ship.Name.Substring(0, 2);
                        if (ship.HDirection == true)
                        {
                            for (int i = startColumn; i <= endColumn; i++)
                            {
                                player1.Board[startRow, i] = letter;
                            }
                        }
                        else if (ship.HDirection == false)
                        {
                            for (int i = startRow; i <= endRow; i++)
                            {
                                player1.Board[i, startColumn] = letter;
                            }
                        }
                    }
                    Logger.ConsoleInformation("------- " + canvasUid + " ------");
                    for (int i = 0; i < RowRep; i++)
                    {
                        for (int j = 0; j < RowRep; j++)
                        {
                            Logger.ConsoleInformationForArray(player1.Board[i, j] + ", ");
                        }

                        Logger.ConsoleInformation("");
                    }
                }
                else if(canvasUid == "Player2Canvas")
                {
                    foreach (Ship ship in this.player2.Playershipcollection)
                    {
                        int startColumn = (int)ship.ShipStartCoords.XCoordinate - 1;
                        int startRow = (int)ship.ShipStartCoords.YCoordinate - 1;
                        int endColumn = (int)ship.ShipEndCoords.XCoordinate - 1;
                        int endRow = (int)ship.ShipEndCoords.YCoordinate - 1;
                        string letter = ship.Name.Substring(0, 2);
                        if (ship.HDirection == true)
                        {
                            for (int i = startColumn; i <= endColumn; i++)
                            {
                                player2.Board[startRow, i] = letter;
                            }
                        }
                        else if (ship.HDirection == false)
                        {
                            for (int i = startRow; i <= endRow; i++)
                            {
                                player2.Board[i, startColumn] = letter;
                            }
                        }
                    }
                    Logger.ConsoleInformation("------- " + canvasUid + " ------");
                    for (int i = 0; i < RowRep; i++)
                    {
                        for (int j = 0; j < RowRep; j++)
                        {
                            Logger.ConsoleInformationForArray(player2.Board[i, j] + ", ");
                        }

                        Logger.ConsoleInformation("");
                    }
                }
            }
            else if ((canvasUid == "Player1Canvas" && this.player1.isLocked == false) || (canvasUid == "Player2Canvas" && this.player2.isLocked == false))
            { 
                this.Confirm_Button.IsEnabled = true;
                this.AttackBtn.IsEnabled = false;
            }
        }

        /// <summary>
        /// Set a confirm ship placement button.
        /// </summary>
        /// <param name="canvasUid">The id of the canvas.</param>
        private void ConfirmShipPlacement(string canvasUid)
        {
            if (canvasUid == "Player1Canvas")
            {
                this.player1.isLocked = true;
                
            }
            else if (canvasUid == "Player2Canvas")
            {
                this.player2.isLocked = true;
            }

            this.SetConfirmButtonVisibility(canvasUid);
        }

        /// <summary>
        /// Converts canvas coordinate into grid coordinate.
        /// </summary>
        /// <param name="canvasX">The canvas x coordinate.</param>
        /// <param name="canvasY">The canvas y coordinate.</param>
        /// <returns>The converted coordinates.</returns>
        private Coordinate ConvertCanvasCoordinatesToGridCoordinates(double canvasX, double canvasY)
        {
            Coordinate gridCoordinate = new Coordinate();

            gridCoordinate.XCoordinate = (short)((canvasX / this.Cellsize) + 1);
            gridCoordinate.YCoordinate = (short)((canvasY / this.Cellsize) + 1);

            return gridCoordinate;
        }

        /// <summary>
        /// Method to update the logical coordinates of the passed in <paramref name="shipToUpdate"/> object.
        /// </summary>
        /// <param name="shipToUpdate">The ship whose coordinates are to be updated.</param>
        /// <param name="shipStartCoords">The starting (top-left) coordinates of the ship.</param>
        /// <param name="shipEndCoords">The ending (bottom-right) coordinates of the ship.</param>
        private void UpdateShipCoords(Ship shipToUpdate, Coordinate shipStartCoords, Coordinate shipEndCoords)
        {
            //Logger.ConsoleInformation("New Ship Start Coords: " + shipStartCoords.XCoordinate.ToString() + ", " + shipStartCoords.YCoordinate.ToString());
            //Logger.ConsoleInformation("New Ship End Coords: " + shipEndCoords.XCoordinate.ToString() + ", " + shipEndCoords.YCoordinate.ToString());
            shipToUpdate.UpdateShipCoords(shipStartCoords, shipEndCoords);
        }

        /// <summary>
        /// Fire missiles
        /// </summary>
        /// <param name="sender">The object that initiated the event</param>
        /// <param name="e">The event arguments for the event.</param>
        private void AttackBtn_Click_1(object sender, RoutedEventArgs e)
        {
            // goto to method to change the screen view
            this.SwitchPlayerWindows();
        }

        /// <summary>
        /// Set a report button click.
        /// </summary>
        /// <param name="sender">The object that initiated the event</param>
        /// <param name="e">The event arguments for the event.</param>
        private void Reportbtn_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Set a confirm button click.
        /// </summary>
        /// <param name="sender">The object that initiated the event</param>
        /// <param name="e">The event arguments for the event.</param>
        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.playerWindow1.Visibility == Visibility.Visible)
            {
                this.ConfirmShipPlacement("Player1Canvas");
            }
            else if (this.playerWindow2.Visibility == Visibility.Visible)
            {
                this.ConfirmShipPlacement("Player2Canvas");
            }
        }
    }
}
