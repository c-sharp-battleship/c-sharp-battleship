//-----------------------------------------------------------------------
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
            // start player one label visible
            PlayerOnelabel.Visibility = Visibility.Visible;
            PlayerTwolabel.Visibility = Visibility.Hidden;
            AttackBtn.IsEnabled = false;

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


            DeclarePlayerGrid(this.player1, this.player2, this.PlayersCellRecords, this.playerWindow1, this.Cellsize);
            DeclarePlayerShips(this.player1, this.playerWindow1, this.Cellsize);

            DeclarePlayerGrid(this.player2, this.player1, this.PlayersCellRecords, this.playerWindow2, this.Cellsize);
            DeclarePlayerShips(this.player2, this.playerWindow2, this.Cellsize);

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
            PlayerOnelabel.Visibility = Visibility.Visible;
            PlayerTwolabel.Visibility = Visibility.Hidden;
            AttackBtn.Visibility = Visibility.Hidden;

            // Create Players with their cells and their ships and grids colors
            // 1 = Black,2=dark blue,3=magenta,4=lightseagreen,5=purple,6=white,standard cadet blue
            this.player1 = new Player(1, "PlayerOne", this.Cellsize, this.RowRep, 1, 3);
            this.player2 = new ComputerPlayer(2, "ComputerPlayerTwo", this.Cellsize, this.RowRep, 3, 6);

            Logger.ConsoleInformation("------- Computer Grid ------");
            for (int i = 0; i < RowRep; i++)
            {
                for (int j = 0; j < RowRep; j++)
                {
                    Logger.ConsoleInformationForArray(player2.Board[i, j] + ", ");
                }

                Logger.ConsoleInformation("");
            }

            // Create two Canvas to place the player elements on them 
            this.playerWindow1 = new Canvas();
            this.playerWindow1.HorizontalAlignment = HorizontalAlignment.Center;
            this.playerWindow1.VerticalAlignment = VerticalAlignment.Center;
            this.playerWindow1.Uid = "Player1Canvas";
            this.playerWindow1.Width = (this.Cellsize * this.RowRep) * 2;
            this.playerWindow1.Visibility = Visibility.Visible;

            DeclarePlayerGrid(this.player1, this.player2, this.PlayersCellRecords, this.playerWindow1, this.Cellsize);
            DeclarePlayerShips(this.player1, this.playerWindow1, this.Cellsize);

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
            PlayerOnelabel.Visibility = Visibility.Visible;
            PlayerTwolabel.Visibility = Visibility.Hidden;
            AttackBtn.Visibility = Visibility.Hidden;
            Confirm_Button.Visibility = Visibility.Hidden;
            
            // Create Players with their cells and their ships and grids colors
            // 1 = Black,2=dark blue,3=magenta,4=lightseagreen,5=purple,6=white,standard cadet blue
            this.player1 = new ComputerPlayer(1, "ComputerPlayerOne", this.Cellsize, this.RowRep, 1, 3);
            this.player2 = new ComputerPlayer(2, "ComputerPlayerTwo", this.Cellsize, this.RowRep, 3, 6);

            Logger.ConsoleInformation("------- Computer Grid ------");
            for (int i = 0; i < RowRep; i++)
            {
                for (int j = 0; j < RowRep; j++)
                {
                    Logger.ConsoleInformationForArray(player1.Board[i, j] + ", ");
                }

                Logger.ConsoleInformation("");
            }
            Logger.ConsoleInformation("------- Computer Grid ------");
            for (int i = 0; i < RowRep; i++)
            {
                for (int j = 0; j < RowRep; j++)
                {
                    Logger.ConsoleInformationForArray(player2.Board[i, j] + ", ");
                }

                Logger.ConsoleInformation("");
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

            DeclareComputerPlayerGrid(this.player1, this.player2, this.PlayersCellRecords, this.playerWindow1, this.Cellsize);
            DeclareComputerPlayerShips(this.player1, this.playerWindow1, this.Cellsize);

            DeclareComputerPlayerGrid(this.player2, this.player1, this.PlayersCellRecords, this.playerWindow2, this.Cellsize);
            DeclareComputerPlayerShips(this.player2, this.playerWindow2, this.Cellsize);

            // load both canvas to this window grid
            this.Maingrid.Children.Add(this.playerWindow1);
            this.Maingrid.Children.Add(this.playerWindow2);

            this.Show();
        }

        private void DeclarePlayerGrid(Player p_currentPlayer, Player p_otherPlayer, List<GridCell> p_playersCellRecords, Canvas p_currentPlayerWindow, double p_cellsize)
        {
            foreach (KeyValuePair<int,GridCell> MainPlayerPair in p_currentPlayer.Playergridsquarecollection)
            {
                int gridcellnumber = MainPlayerPair.Key;
                GridCell MainPlayerCell = MainPlayerPair.Value;

                // add a click event for all cells in Player 1 grid only if the button is attack type
                if (MainPlayerCell.OffenseButton == true)
                {
                    // add click event
                    MainPlayerCell.Click += new RoutedEventHandler(delegate(object sender, RoutedEventArgs e)
                    {
                        // go check the list of buttons for player two and change the status for them
                        foreach (KeyValuePair<int,GridCell> otherPlayerPair in p_otherPlayer.Playergridsquarecollection)
                        {
                            int otherPlayercellnumber = otherPlayerPair.Key;
                            GridCell otherPlayerPlayerCell = otherPlayerPair.Value;
                            // turn off buttons on the enemy grid(player two left side)only if it is a defense button
                            if (MainPlayerCell.Uid == otherPlayerPlayerCell.Uid && otherPlayerPlayerCell.OffenseButton == false)
                            {
                                // make changes to player two grid
                                otherPlayerPlayerCell.Background = Brushes.Red;

                                otherPlayerPlayerCell.Content = "X";
                                otherPlayerPlayerCell.Stricked = 1;
                                otherPlayerPlayerCell.AllowDrop = false;

                                /*foreach (Ship NavyShip in p_otherPlayer.Playershipcollection)
                                {
                                    foreach (int cell in NavyShip.Ship_Crewmembers)
                                    {
                                        MessageBox.Show(cell.ToString());

                                        
                                        if (otherPlayerPlayerCell.TrackingID == cell)
                                        {
                                            MessageBox.Show("You Just Hit my" + NavyShip.Name);
                                        }
                                        else { MessageBox.Show("You wont Succed"); }
                                        
                                    }
                                }*/
                                int rowNum;
                                if ((gridcellnumber - 100) % 10 == 0)
                                {
                                    rowNum = (gridcellnumber - 100) / 10 - 1;
                                }
                                else
                                {
                                    rowNum = (gridcellnumber - 100) / 10;
                                }
                                int colNum = ((gridcellnumber-100) - (gridcellnumber-100) / 10 * 10) -1;
                                if (colNum == -1)
                                {
                                    colNum = 9;
                                }
                                string letterAttackGrid = p_otherPlayer.Board[rowNum, colNum];
                                if (letterAttackGrid != "O" && letterAttackGrid != "H" && letterAttackGrid != "M")
                                {
                                    p_otherPlayer.Board[rowNum, colNum] = "H" + letterAttackGrid;
                                    MainPlayerCell.Background = Brushes.Green;
                                    MainPlayerCell.Content = "H";
                                    MainPlayerCell.IsEnabled = false;
                                    MainPlayerCell.Stricked = 1;
                                    MainPlayerCell.AllowDrop = false;
                                }
                                else
                                {
                                    MainPlayerCell.Visibility = Visibility.Hidden;
                                    p_otherPlayer.Board[rowNum, colNum] = "M";
                                }
                            }
                        }

                        Coordinate attackedGridSpace = new Coordinate((short)MainPlayerCell.ColNum, (short)MainPlayerCell.RowNum);

                        Logger.ConsoleInformation("Row Number: " + MainPlayerCell.RowNum);
                        Logger.ConsoleInformation("Column Number: " + MainPlayerCell.ColNum);

                        foreach (Ship testShip in p_currentPlayer.Playershipcollection)
                        {
                            AttackCoordinate tempCoordainte = testShip.AttackGridSpace(attackedGridSpace);
                        }

                        // Swicth windows between players 
                        if (p_otherPlayer.Name == "ComputerPlayerTwo")
                        {
                            Coordinate position = ((ComputerPlayer)p_otherPlayer).SetRandomAttackCoordinate(p_currentPlayer);
                            Logger.ConsoleInformation(position.XCoordinate.ToString() + ' '+ position.YCoordinate.ToString());
                            foreach (KeyValuePair<int, GridCell> playerPair in p_currentPlayer.Playergridsquarecollection)
                            {
                                GridCell playerCell = playerPair.Value;
                                int y = (position.YCoordinate + 1) * 10 + (position.XCoordinate + 1);
                                if (playerPair.Key == position.YCoordinate * 10 + (position.XCoordinate + 1) &&
                                    playerCell.OffenseButton == false)
                                {
                                    // make changes to player two grid
                                    playerCell.Background = Brushes.Red;
                                    playerCell.Content = "X";
                                    playerCell.Stricked = 1;
                                    playerCell.AllowDrop = false;
                                }
                            }
                            Logger.ConsoleInformation("------- Computer Grid ------");
                            for (int i = 0; i < RowRep; i++)
                            {
                                for (int j = 0; j < RowRep; j++)
                                {
                                    Logger.ConsoleInformationForArray(player2.Board[i, j] + ", ");
                                }

                                Logger.ConsoleInformation("");
                            }
                        }
                        else
                        {
                            this.SwitchPlayerWindows();
                        }
                    });
                }
                else
                {
                    // add the drag over event for when ships are dragged over the cells only if the cell is deffense type
                    // Create a method when an object is drag over this left button
                    MainPlayerCell.DragOver += new DragEventHandler(delegate (object sender, DragEventArgs e)
                    {
                        // find the sender uid extracting the date of the event
                        string myWarshipUid = e.Data.GetData(DataFormats.StringFormat).ToString();

                        // iterate thru the collection of ships to find the sender element with matching uid
                        foreach (Ship Myship in p_currentPlayer.Playershipcollection)
                        {
                            // if the sender element uid matches then this is my element, then move it with the mouse
                            if (myWarshipUid == Myship.Uid)
                            {
                                double shipMaxX = (p_currentPlayerWindow.Width / 2) - (Myship.Width) + p_cellsize;
                                double shipMaxY = (p_currentPlayerWindow.Width / 2) - (Myship.Height) + p_cellsize;

                                //check this method to see if its ok to move ship to requested cell
                                int OverlappingCrew = SetshipMovePerCrewCheck(Myship, MainPlayerCell, p_currentPlayer,0);

                                if (OverlappingCrew == 0)
                                {
                                    Point grabPos = e.GetPosition(p_currentPlayerWindow);
                                    if (grabPos.X < shipMaxX && grabPos.Y < shipMaxY)
                                    {
                                        Myship.Delayed_Crew_Crewmembers = Myship.SetCrewmembers(MainPlayerCell.TrackingID,0);
                                        Canvas.SetTop(Myship, MainPlayerCell.Top_Comp_ParentTop);
                                        Myship.Top_Comp_ParentTop = MainPlayerCell.Top_Comp_ParentTop;
                                        Canvas.SetLeft(Myship, MainPlayerCell.Left_Comp_ParentLeft);
                                        Myship.Left_Comp_ParentLeft = MainPlayerCell.Left_Comp_ParentLeft;
                                        Myship.Captain = MainPlayerCell.TrackingID;

                                        Coordinate shipStartCoords = this.ConvertCanvasCoordinatesToGridCoordinates(grabPos.X, grabPos.Y);
                                        Coordinate shipEndCoords = this.ConvertCanvasCoordinatesToGridCoordinates(grabPos.X, grabPos.Y);
                                        if (Myship.HDirection == true)
                                        {
                                            shipEndCoords.XCoordinate += (short)((Myship.Width / p_cellsize) - 1);
                                        }
                                        else if (Myship.HDirection == false)
                                        {
                                            shipEndCoords.YCoordinate += (short)((Myship.Height / p_cellsize) - 1);
                                        }
                                        this.UpdateShipCoords(Myship, shipStartCoords, shipEndCoords);
                                    }
                                }
                            
                            }
                        }
                    });
                }

                //// Add player 1 cells to the window grid
                p_currentPlayerWindow.Children.Add(MainPlayerCell);
            }
        }

        /// <summary>
        /// return a confirmation to do a move if there is no ships overlapping
        /// </summary>
        /// <param name="Myship"></param>
        /// <param name="MainPlayerCell"></param>
        /// <param name="p_currentPlayer"></param>
        /// <returns></returns>
        private int SetshipMovePerCrewCheck(Ship Myship, GridCell MainPlayerCell, Player p_currentPlayer, int Drag_Turn)
        {
            int OverlapingCrewMembers = 0;
            int newCaptain = MainPlayerCell.TrackingID;
            List<int> NewCrewmembers = new List<int>();
            NewCrewmembers = Myship.SetCrewmembers(newCaptain, Drag_Turn);

            foreach (int NewMember in NewCrewmembers)
            {
                // Logger.ConsoleInformation(NewMember.ToString());
                foreach (Ship ShipCheck in p_currentPlayer.Playershipcollection)
                {
                    if (ShipCheck.Uid != Myship.Uid)
                    {
                        foreach (int OldCrewMember in ShipCheck.Delayed_Crew_Crewmembers)
                        {
                            if (NewMember == OldCrewMember)
                            {
                                OverlapingCrewMembers++;
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            return OverlapingCrewMembers;
        }

        private void DeclareComputerPlayerGrid(Player p_currentPlayer, Player p_otherPlayer, List<GridCell> p_playersCellRecords, Canvas p_currentPlayerWindow, double p_cellsize)
        {
            foreach (GridCell currentPlayerOffenseButton in p_currentPlayer.PlayerGridCellList)
            {
                p_playersCellRecords.Add(currentPlayerOffenseButton);

                Coordinate position = ((ComputerPlayer)p_currentPlayer).SetRandomAttackCoordinate(p_otherPlayer);

                foreach (KeyValuePair<int, GridCell> otherPlayerPair in p_otherPlayer.Playergridsquarecollection)
                {
                    GridCell playerCell = otherPlayerPair.Value;
                    int y = (position.YCoordinate + 1) * 10 + (position.XCoordinate + 1);
                    if (otherPlayerPair.Key == position.YCoordinate * 10 + (position.XCoordinate + 1) &&
                        playerCell.OffenseButton == false)
                    {
                        // make changes to player two grid
                        playerCell.Background = Brushes.Red;
                        playerCell.Content = "X";
                        playerCell.Stricked = 1;
                        playerCell.AllowDrop = false;
                    }
                }
                    // add a click event for all cells in Player 1 grid only if the button is attack type
                    if (currentPlayerOffenseButton.OffenseButton == true)
                {
                    foreach (KeyValuePair<int, GridCell> otherPlayerPair in p_otherPlayer.Playergridsquarecollection)
                    {
                        GridCell otherPlayerDefenseButton = otherPlayerPair.Value;
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
                }
                
                //// Add player 1 cells to the window grid
                p_currentPlayerWindow.Children.Add(currentPlayerOffenseButton);
            }
        }
        
        private void DeclarePlayerShips(Player p_currentPlayer, Canvas p_currentPlayerWindow, double p_cellsize)
        {
            foreach (Ship NavyShip in p_currentPlayer.Playershipcollection)
            {
                NavyShip.MouseRightButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs e)
                {
                    if (p_currentPlayer.isLocked == false)
                    {
                        //create a cell to pass a cell to this method and return the possible crew members for this turn
                        GridCell Fakecell = new GridCell(p_currentPlayer.PlayerID,0,"");
                        Fakecell.TrackingID = NavyShip.Captain;
                        int Overlappingcrew = SetshipMovePerCrewCheck(NavyShip, Fakecell, p_currentPlayer,1);

                        if (Overlappingcrew == 0)
                        {
                            if (NavyShip.HDirection == true)
                            {
                                double shipMaxX = (p_currentPlayerWindow.Width / 2) - (NavyShip.Height);
                                double shipMaxY = (p_currentPlayerWindow.Width / 2) - (NavyShip.Width);

                                if (NavyShip.Top_Comp_ParentTop <= shipMaxY && NavyShip.LeftToParentLeft <= shipMaxX)
                                {
                                    NavyShip.RotateShip(true);
                                    NavyShip.Delayed_Crew_Crewmembers = NavyShip.SetCrewmembers(NavyShip.Captain, 0);
                                }
                            }
                            else
                            {
                                double shipMaxX = (p_currentPlayerWindow.Width / 2) - (NavyShip.Height);
                                double shipMaxY = (p_currentPlayerWindow.Width / 2) - (NavyShip.Width);

                                if (NavyShip.Top_Comp_ParentTop <= shipMaxY && NavyShip.LeftToParentLeft <= shipMaxX)
                                {
                                    NavyShip.RotateShip(true);
                                    NavyShip.Delayed_Crew_Crewmembers = NavyShip.SetCrewmembers(NavyShip.Captain, 0);
                                }
                            }
                        }
                    }
                });

                // create a move move event for player 1 ships to attacch the rectangle to the mouse
                NavyShip.MouseMove += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
                {
                    if (p_currentPlayer.isLocked == false)
                    {
                        if (e.LeftButton == MouseButtonState.Pressed)
                        {
                            //This if statement will be used when the ship enters the boards for the first time
                            int dragfirsttime = NavyShip.DragsCounter;
                            if (dragfirsttime > 0)
                            {
                                string objectUniqueID = NavyShip.Uid;
                                DragDrop.DoDragDrop(NavyShip, objectUniqueID, DragDropEffects.Move);
                            }
                            else
                            {
                                Canvas.SetTop(NavyShip, NavyShip.Top_Comp_ParentTop);
                                Canvas.SetLeft(NavyShip, NavyShip.LeftToParentLeft);
                                NavyShip.DragsCounter += 1;
                            }
                        }
                    }
                });

                // Add player 1 Ships to the window grid
                p_currentPlayerWindow.Children.Add(NavyShip);
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
            else if (canvasUid == "Player2Canvas")
            {
                this.player2.isLocked = true;
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
