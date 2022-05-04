//-----------------------------------------------------------------------
// <copyright file="GameWindow.xaml.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for GameWindow.xaml.
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

        private StatusCodes.ComputerPlayerDifficulty computerPlayerDifficulty1;

        private StatusCodes.ComputerPlayerDifficulty computerPlayerDifficulty2;

        /// <summary>
        /// The player 1 window.
        /// </summary>
        private Canvas playerWindow1;

        /// <summary>
        /// The player 2 window.
        /// </summary>
        private Canvas playerWindow2;

        private DispatcherTimer dispatcherTimer;

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
            }
        }

        /// <summary>
        ///  Gets a value indicating whether screen player1 is visible or not.
        /// </summary>
        public bool Switch
        {
            get { return this.screenPlayerOne; }
        }

        /// <summary>
        ///  Gets or sets a computer player 1 difficulty.
        /// </summary>
        public StatusCodes.ComputerPlayerDifficulty ComputerPlayerDifficulty1
        {
            get { return this.computerPlayerDifficulty1; }
            set { this.computerPlayerDifficulty1 = value; }
        }

        /// <summary>
        ///  Gets or sets a computer player 2 difficulty.
        /// </summary>
        public StatusCodes.ComputerPlayerDifficulty ComputerPlayerDifficulty2
        {
            get { return this.computerPlayerDifficulty2; }
            set { this.computerPlayerDifficulty2 = value; }
        }

        /// <summary>
        /// Start a player to player game.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        public void StartPlayerToPlayerGame(object sender, EventArgs e)
        {
            // start player one label visible
            this.PlayerOnelabel.Visibility = Visibility.Visible;
            this.PlayerTwolabel.Visibility = Visibility.Hidden;
            this.AttackBtn.IsEnabled = false;

            // Create Players with their cells and their ships and grids colors
            // 1 = Black,2=dark blue,3=magenta,4=lightseagreen,5=purple,6=white,standard cadet blue
            this.player1 = new Player(1, "PlayerOne", this.Cellsize, this.RowRep, 1, 3);
            this.player2 = new Player(2, "PlayerTwo", this.Cellsize, this.RowRep, 3, 6);

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

            this.DeclarePlayerGrid(this.player1, this.player2, this.PlayersCellRecords, this.playerWindow1, this.Cellsize);
            this.DeclarePlayerShips(this.player1, this.playerWindow1, this.Cellsize);

            this.DeclarePlayerGrid(this.player2, this.player1, this.PlayersCellRecords, this.playerWindow2, this.Cellsize);
            this.DeclarePlayerShips(this.player2, this.playerWindow2, this.Cellsize);

            // load both canvas to this window grid
            this.Maingrid.Children.Add(this.playerWindow1);
            this.Maingrid.Children.Add(this.playerWindow2);

            this.Show();
        }

        /// <summary>
        /// Start a player to computer game.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        public void StartPlayerToComputerGame(object sender, EventArgs e)
        {
            // start player one label visible
            this.PlayerOnelabel.Visibility = Visibility.Visible;
            this.PlayerTwolabel.Visibility = Visibility.Hidden;
            this.AttackBtn.Visibility = Visibility.Hidden;

            // Create Players with their cells and their ships and grids colors
            // 1 = Black,2=dark blue,3=magenta,4=lightseagreen,5=purple,6=white,standard cadet blue
            this.player1 = new Player(1, "PlayerOne", this.Cellsize, this.RowRep, 1, 3);
            this.player2 = new ComputerPlayer(2, "ComputerPlayerTwo", this.Cellsize, this.RowRep, 3, 6, this.computerPlayerDifficulty1);
            this.player2.IsLocked = true;

            Logger.ConsoleInformation("------- Computer Grid ------");
            for (int i = 0; i < this.RowRep; i++)
            {
                for (int j = 0; j < this.RowRep; j++)
                {
                    Logger.ConsoleInformationForArray(this.player2.Board[i, j] + ", ");
                }

                Logger.ConsoleInformation("\n");
            }

            // Create two Canvas to place the player elements on them
            this.playerWindow1 = new Canvas();
            this.playerWindow1.HorizontalAlignment = HorizontalAlignment.Center;
            this.playerWindow1.VerticalAlignment = VerticalAlignment.Center;
            this.playerWindow1.Uid = "Player1Canvas";
            this.playerWindow1.Width = (this.Cellsize * this.RowRep) * 2;
            this.playerWindow1.Visibility = Visibility.Visible;

            this.DeclarePlayerGrid(this.player1, this.player2, this.PlayersCellRecords, this.playerWindow1, this.Cellsize);
            this.DeclarePlayerShips(this.player1, this.playerWindow1, this.Cellsize);

            // load both canvas to this window grid
            this.Maingrid.Children.Add(this.playerWindow1);

            this.Show();
        }

        /// <summary>
        /// Start a computer to computer game.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        public void StartComputerToComputerGame(object sender, EventArgs e)
        {
            // start player one label visible
            this.PlayerOnelabel.Visibility = Visibility.Visible;
            this.PlayerTwolabel.Visibility = Visibility.Hidden;
            this.AttackBtn.Visibility = Visibility.Hidden;
            this.Confirm_Button.Visibility = Visibility.Hidden;

            // Create Players with their cells and their ships and grids colors
            // 1 = Black,2=dark blue,3=magenta,4=lightseagreen,5=purple,6=white,standard cadet blue
            this.player1 = new ComputerPlayer(1, "ComputerPlayerOne", this.Cellsize, this.RowRep, 1, 3, this.computerPlayerDifficulty1);
            this.player2 = new ComputerPlayer(2, "ComputerPlayerTwo", this.Cellsize, this.RowRep, 3, 6, this.computerPlayerDifficulty2);

            Logger.ConsoleInformation("------- Computer Grid ------");
            for (int i = 0; i < this.RowRep; i++)
            {
                for (int j = 0; j < this.RowRep; j++)
                {
                    Logger.ConsoleInformationForArray(this.player1.Board[i, j] + ", ");
                }

                Logger.ConsoleInformation("\n");
            }

            Logger.ConsoleInformation("------- Computer Grid ------");
            for (int i = 0; i < this.RowRep; i++)
            {
                for (int j = 0; j < this.RowRep; j++)
                {
                    Logger.ConsoleInformationForArray(this.player2.Board[i, j] + ", ");
                }

                Logger.ConsoleInformation("\n");
            }

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

            this.DeclareComputerPlayerGrid(this.player1, this.player2, this.PlayersCellRecords, this.playerWindow1, this.Cellsize);
            this.DeclareComputerPlayerShips(this.player1, this.playerWindow1, this.Cellsize);

            this.DeclareComputerPlayerGrid(this.player2, this.player1, this.PlayersCellRecords, this.playerWindow2, this.Cellsize);
            this.DeclareComputerPlayerShips(this.player2, this.playerWindow2, this.Cellsize);

            // load both canvas to this window grid
            this.Maingrid.Children.Add(this.playerWindow1);
            this.Maingrid.Children.Add(this.playerWindow2);

            this.dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            this.dispatcherTimer.Tick += this.DispatcherTimer_Tick;
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            this.dispatcherTimer.Start();

            this.Show();
        }

        /// <summary>
        /// Make the windows visible with Attack button.
        /// </summary>
        public void SwitchPlayerWindows()
        {
            if (this.screenPlayerOne == true)
            {
                // change the visual to off for player 1 and turn on the vissible to player two canvas
                this.screenPlayerOne = false;
                this.PlayerOnelabel.Visibility = Visibility.Hidden;
                this.PlayerTwolabel.Visibility = Visibility.Visible;
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
                this.PlayerOnelabel.Visibility = Visibility.Visible;
                this.PlayerTwolabel.Visibility = Visibility.Hidden;

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

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (this.player1.Winner || this.player2.Winner)
            {
                this.dispatcherTimer.Stop();
            }
            else
            {
                ((ComputerPlayer)this.player1).CompPlayerAttack(this.player2, this.RowRep);
                this.SwitchPlayerWindows();
                ((ComputerPlayer)this.player2).CompPlayerAttack(this.player1, this.RowRep);
            }
        }

        private void DeclarePlayerGrid(Player p_currentPlayer, Player p_otherPlayer, List<GridCell> p_playersCellRecords, Canvas p_currentPlayerWindow, double p_cellsize)
        {
            foreach (KeyValuePair<int, GridCell> mainPlayerPair in p_currentPlayer.Playergridsquarecollection)
            {
                int gridcellnumber = mainPlayerPair.Key;
                GridCell mainPlayerCell = mainPlayerPair.Value;

                // add a click event for all cells in Player 1 grid only if the button is attack type
                if (mainPlayerCell.OffenseButton == true)
                {
                    // add click event
                    mainPlayerCell.Click += new RoutedEventHandler(delegate(object sender, RoutedEventArgs e)
                    {
                        // Double-check that both players ships are locked into place before allowing the user to attack grid spaces.
                        if (p_currentPlayer.IsLocked == true && p_otherPlayer.IsLocked == true)
                        {
                            // go check the list of buttons for player two and change the status for them
                            foreach (KeyValuePair<int, GridCell> otherPlayerPair in p_otherPlayer.Playergridsquarecollection)
                            {
                                int otherPlayercellnumber = otherPlayerPair.Key;
                                GridCell otherPlayerPlayerCell = otherPlayerPair.Value;

                                // turn off buttons on the enemy grid(player two left side)only if it is a defense button
                                if (mainPlayerCell.Uid == otherPlayerPlayerCell.Uid &&
                                    otherPlayerPlayerCell.OffenseButton == false)
                                {
                                    // make changes to player two grid
                                    otherPlayerPlayerCell.Background = Brushes.Red;

                                    otherPlayerPlayerCell.Content = "X";
                                    otherPlayerPlayerCell.Stricked = 1;
                                    otherPlayerPlayerCell.AllowDrop = false;

                                    int rowNum;
                                    if ((gridcellnumber - 100) % 10 == 0)
                                    {
                                        rowNum = ((gridcellnumber - 100) / 10) - 1;
                                    }
                                    else
                                    {
                                        rowNum = (gridcellnumber - 100) / 10;
                                    }

                                    int colNum = ((gridcellnumber - 100) - (((gridcellnumber - 100) / 10) * 10)) - 1;
                                    if (colNum == -1)
                                    {
                                        colNum = 9;
                                    }

                                    string letterAttackGrid = p_otherPlayer.Board[rowNum, colNum];
                                    if (letterAttackGrid != "O" && letterAttackGrid != "H" && letterAttackGrid != "M")
                                    {
                                        p_otherPlayer.Board[rowNum, colNum] = "H";
                                        mainPlayerCell.Background = Brushes.Green;
                                        mainPlayerCell.Content = "H";
                                        mainPlayerCell.IsEnabled = false;
                                        mainPlayerCell.Stricked = 1;
                                        mainPlayerCell.AllowDrop = false;
                                    }
                                    else
                                    {
                                        mainPlayerCell.Visibility = Visibility.Hidden;
                                        p_otherPlayer.Board[rowNum, colNum] = "M";
                                    }
                                }
                            }

                            Coordinate attackedGridSpace = new Coordinate((short)mainPlayerCell.ColNum, (short)mainPlayerCell.RowNum);

                            Logger.ConsoleInformation("Row Number: " + mainPlayerCell.RowNum);
                            Logger.ConsoleInformation("Column Number: " + mainPlayerCell.ColNum);

                            foreach (Ship testShip in p_otherPlayer.Playershipcollection)
                            {
                                // Logger.Information(testShip.ShipStartCoords.XCoordinate.ToString() + " "+ testShip.ShipStartCoords.YCoordinate.ToString());
                                AttackCoordinate tempCoordainte = testShip.AttackGridSpace(attackedGridSpace);
                            }

                            // Swicth windows between players
                            if (p_otherPlayer.Name == "ComputerPlayerTwo")
                            {
                                if (ComputerPlayerDifficulty1 ==
                                    StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_HARD)
                                {
                                    ((ComputerPlayer)p_otherPlayer).AdvancedAttack(p_currentPlayer, this.RowRep);
                                }
                                else
                                {
                                    ((ComputerPlayer)p_otherPlayer).CompPlayerAttack(p_currentPlayer, this.RowRep);
                                }
                            }
                            else
                            {
                                this.SwitchPlayerWindows();
                            }
                        }
                        else
                        {
                            // If the current player's ship placement is locked, but the other player's ship placement is not locked, let the player know.
                            if (p_currentPlayer.IsLocked == true && p_otherPlayer.IsLocked == false)
                            {
                                Logger.Error("Error: The other player has not yet confirmed their ship placement.");
                            }

                            // Otherwise, let the user know that they need to confirm ship placement.
                            else
                            {
                                Logger.Error("Error: Please confirm your ship placement before proceeding to attack.");
                            }
                        }
                    });
                }
                else
                {
                    // add the drag over event for when ships are dragged over the cells only if the cell is deffense type
                    // Create a method when an object is drag over this left button
                    mainPlayerCell.DragOver += new DragEventHandler(delegate(object sender, DragEventArgs e)
                    {
                        // find the sender uid extracting the date of the event
                        string myWarshipUid = e.Data.GetData(DataFormats.StringFormat).ToString();

                        // iterate thru the collection of ships to find the sender element with matching uid
                        foreach (Ship myShip in p_currentPlayer.Playershipcollection)
                        {
                            // if the sender element uid matches then this is my element, then move it with the mouse
                            if (myWarshipUid == myShip.Uid)
                            {
                                double shipMaxX = (p_currentPlayerWindow.Width / 2) - myShip.Width + p_cellsize;
                                double shipMaxY = (p_currentPlayerWindow.Width / 2) - myShip.Height + p_cellsize;

                                // check this method to see if its ok to move ship to requested cell
                                int overlappingCrew = this.SetshipMovePerCrewCheck(myShip, mainPlayerCell, p_currentPlayer, 0);

                                if (overlappingCrew == 0)
                                {
                                    Point grabPos = e.GetPosition(p_currentPlayerWindow);
                                    if (grabPos.X < shipMaxX && grabPos.Y < shipMaxY)
                                    {
                                        myShip.Delayed_Crew_Crewmembers = myShip.SetCrewmembers(mainPlayerCell.TrackingID, 0);
                                        Canvas.SetTop(myShip, mainPlayerCell.Top_Comp_ParentTop);
                                        myShip.Top_Comp_ParentTop = mainPlayerCell.Top_Comp_ParentTop;
                                        Canvas.SetLeft(myShip, mainPlayerCell.Left_Comp_ParentLeft);
                                        myShip.Left_Comp_ParentLeft = mainPlayerCell.Left_Comp_ParentLeft;
                                        myShip.Captain = mainPlayerCell.TrackingID;

                                        Coordinate shipStartCoords = this.ConvertCanvasCoordinatesToGridCoordinates(grabPos.X, grabPos.Y);
                                        Coordinate shipEndCoords = this.ConvertCanvasCoordinatesToGridCoordinates(grabPos.X, grabPos.Y);
                                        if (myShip.HDirection == true)
                                        {
                                            shipEndCoords.XCoordinate += (short)((myShip.Width / p_cellsize) - 1);
                                        }
                                        else if (myShip.HDirection == false)
                                        {
                                            shipEndCoords.YCoordinate += (short)((myShip.Height / p_cellsize) - 1);
                                        }

                                        this.UpdateShipCoords(myShip, shipStartCoords, shipEndCoords);
                                    }
                                }
                            }
                        }
                    });
                }

                //// Add player 1 cells to the window grid
                p_currentPlayerWindow.Children.Add(mainPlayerCell);
            }
        }

        /// <summary>
        /// Return a confirmation to do a move if there is no ships overlapping.
        /// </summary>
        /// <param name="myShip">The ship to be checked.</param>
        /// <param name="mainPlayerCell">The former grid space of the captain.</param>
        /// <param name="p_currentPlayer">The current player.</param>
        /// <returns>The new captain of the ship.</returns>
        private int SetshipMovePerCrewCheck(Ship myShip, GridCell mainPlayerCell, Player p_currentPlayer, int dragTurn)
        {
            int overlapingCrewMembers = 0;
            int newCaptain = mainPlayerCell.TrackingID;
            List<int> newCrewmembers = new List<int>();
            newCrewmembers = myShip.SetCrewmembers(newCaptain, dragTurn);

            foreach (int newMember in newCrewmembers)
            {
                // Logger.ConsoleInformation(newMember.ToString());
                foreach (Ship shipCheck in p_currentPlayer.Playershipcollection)
                {
                    if (shipCheck.Uid != myShip.Uid)
                    {
                        foreach (int oldCrewMember in shipCheck.Delayed_Crew_Crewmembers)
                        {
                            if (newMember == oldCrewMember)
                            {
                                overlapingCrewMembers++;
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }

            return overlapingCrewMembers;
        }

        private void DeclareComputerPlayerGrid(Player p_currentPlayer, Player p_otherPlayer, List<GridCell> p_playersCellRecords, Canvas p_currentPlayerWindow, double p_cellsize)
        {
            foreach (KeyValuePair<int, GridCell> mainPlayerPair in p_currentPlayer.Playergridsquarecollection)
            {
                int gridcellnumber = mainPlayerPair.Key;
                GridCell mainPlayerCell = mainPlayerPair.Value;

                //// Add player cells to the window grid
                p_currentPlayerWindow.Children.Add(mainPlayerCell);
            }
        }

        private void DeclarePlayerShips(Player p_currentPlayer, Canvas p_currentPlayerWindow, double p_cellsize)
        {
            foreach (Ship navyShip in p_currentPlayer.Playershipcollection)
            {
                navyShip.MouseRightButtonDown += new MouseButtonEventHandler(delegate(object sender, MouseButtonEventArgs e)
                {
                    if (p_currentPlayer.IsLocked == false)
                    {
                        // create a cell to pass a cell to this method and return the possible crew members for this turn
                        GridCell fakecell = new GridCell(p_currentPlayer.PlayerID, 0, "");
                        fakecell.TrackingID = navyShip.Captain;
                        int overlappingCrew = this.SetshipMovePerCrewCheck(navyShip, fakecell, p_currentPlayer, 1);

                        if (overlappingCrew == 0)
                        {
                            double shipMaxX = (p_currentPlayerWindow.Width / 2) - navyShip.Height;
                            double shipMaxY = (p_currentPlayerWindow.Width / 2) - navyShip.Width;

                            if (navyShip.Top_Comp_ParentTop <= shipMaxY && navyShip.LeftToParentLeft <= shipMaxX)
                            {
                                navyShip.RotateShip(true);
                                navyShip.Delayed_Crew_Crewmembers = navyShip.SetCrewmembers(navyShip.Captain, 0);
                            }
                        }
                    }
                });

                // create a move move event for player 1 ships to attacch the rectangle to the mouse
                navyShip.MouseMove += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
                {
                    if (p_currentPlayer.IsLocked == false)
                    {
                        if (e.LeftButton == MouseButtonState.Pressed)
                        {
                            // This if statement will be used when the ship enters the boards for the first time
                            int dragfirsttime = navyShip.DragsCounter;
                            if (dragfirsttime > 0)
                            {
                                string objectUniqueID = navyShip.Uid;
                                DragDrop.DoDragDrop(navyShip, objectUniqueID, DragDropEffects.Move);
                            }
                            else
                            {
                                Canvas.SetTop(navyShip, navyShip.Top_Comp_ParentTop);
                                Canvas.SetLeft(navyShip, navyShip.LeftToParentLeft);
                                navyShip.DragsCounter += 1;
                            }
                        }
                    }
                });

                // Add player 1 Ships to the window grid
                p_currentPlayerWindow.Children.Add(navyShip);
            }
        }

        private void DeclareComputerPlayerShips(Player p_currentPlayer, Canvas p_currentPlayerWindow, double p_cellsize)
        {
            foreach (Ship ship_1 in p_currentPlayer.Playershipcollection)
            {
                // Add player 1 Ships to the window grid
                p_currentPlayerWindow.Children.Add(ship_1);
            }
        }

        /// <summary>
        /// Set a confirm button visibility.
        /// </summary>
        /// <param name="canvasUid">The id of the canvas.</param>
        private void SetConfirmButtonVisibility(string canvasUid)
        {
            if ((canvasUid == "Player1Canvas" && this.player1.IsLocked == true) || (canvasUid == "Player2Canvas" && this.player2.IsLocked == true))
            {
                this.Confirm_Button.IsEnabled = false;
                this.AttackBtn.IsEnabled = true;
            }
            else if ((canvasUid == "Player1Canvas" && this.player1.IsLocked == false) || (canvasUid == "Player2Canvas" && this.player2.IsLocked == false))
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
                this.player1.IsLocked = true;
                this.player1.LockShipsIntoPlace();
                this.player1.SetShipsToBoard(canvasUid, this.RowRep);
            }
            else if (canvasUid == "Player2Canvas")
            {
                this.player2.IsLocked = true;
                this.player2.LockShipsIntoPlace();
                this.player2.SetShipsToBoard(canvasUid, this.RowRep);
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
            // Logger.ConsoleInformation("New Ship Start Coords: " + shipStartCoords.XCoordinate.ToString() + ", " + shipStartCoords.YCoordinate.ToString());
            // Logger.ConsoleInformation("New Ship End Coords: " + shipEndCoords.XCoordinate.ToString() + ", " + shipEndCoords.YCoordinate.ToString());
            shipToUpdate.UpdateShipCoords(shipStartCoords, shipEndCoords);
        }

        /// <summary>
        /// Fire missiles.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void AttackBtn_Click_1(object sender, RoutedEventArgs e)
        {
            // goto to method to change the screen view
            this.SwitchPlayerWindows();
        }

        /// <summary>
        /// Set a report button click.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void Reportbtn_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Set a confirm button click.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
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
