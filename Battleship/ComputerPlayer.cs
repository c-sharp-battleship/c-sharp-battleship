//-----------------------------------------------------------------------
// <copyright file="ComputerPlayer.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Eventing.Reader;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for ComputerPlayer.
    /// </summary>
    public class ComputerPlayer : Player
    {
        /// <summary>
        /// The difficulty level of the computer.
        /// </summary>
        private StatusCodes.ComputerPlayerDifficulty difficulty;

        /// <summary>
        /// The list of hits that the computer made.
        /// </summary>
        private List<int> hitList;

        /// <summary>
        /// The length of the attack ship.
        /// </summary>
        private int attackShipLength;

        /// <summary>
        /// The name of the attack ship.
        /// </summary>
        private string attackShipName;

        /// <summary>
        /// The direction of the attack ship.
        /// </summary>
        private bool attackShipDirection = true;

        /// <summary>
        /// The pervious grid space that was attacked.
        /// </summary>
        private int prevGrid;

        /// <summary>
        /// The list of previously-attacked grid spaces.
        /// </summary>
        private List<int> alreadyAttackedGrids;

        /// <summary>
        /// The list of attacked grid spaces.
        /// </summary>
        private List<int> attackedList;

        /// <summary>
        /// Boolean that describes whether or not the computer is allowed to attack.
        /// </summary>
        private bool allow;

        /// <summary>
        ///  Initializes a new instance of the <see cref="ComputerPlayer" /> class.
        /// </summary>
        /// <param name="player_ID"> This is the ID of the player. </param>
        /// <param name="player_Name"> this is the name of the Player.</param>
        /// <param name="gridcellSize"> This is the size in pixels for the grid square dimension.</param>
        /// <param name="maxCol"> This is the max number of columns requested at the moment pf loading.</param>
        /// <param name="buttoncolorForDeffense"> this is the color for the button created, refer to Custom button class(switch case in constructor).</param>
        /// <param name="buttoncolorForOffense"> This is the side of the screen to load the canvas, if left then reversed count, if right then incremental from one.</param>
        /// <param name="difficulty"> This is the difficulty of the player. </param>
        /// <param name="shipTypes">The types of ships to be instantiated (advanced option).</param>
        public ComputerPlayer(int player_ID, string player_Name, double gridcellSize, int maxCol, int buttoncolorForDeffense, int buttoncolorForOffense, StatusCodes.ComputerPlayerDifficulty difficulty, List<int> shipTypes)
            : base(player_ID, player_Name, gridcellSize, maxCol, buttoncolorForDeffense, buttoncolorForOffense, shipTypes, 2)
        {
            this.difficulty = difficulty;

            this.hitList = new List<int>();
            this.alreadyAttackedGrids = new List<int>();
            this.attackedList = new List<int>();

            // List of ships for each player to return to the personal grid builder
            List<Ship> shiploader = new List<Ship>();

            Dictionary<int, GridCell> playerGridCellsComputer = new Dictionary<int, GridCell>();

            // List of Alphabet letters to give names to gridcells
            string[] capital_letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            this.board = new string[maxCol, maxCol];

            for (int i = 0; i < maxCol; i++)
            {
                for (int j = 0; j < maxCol; j++)
                {
                    this.board[i, j] = "O";
                }
            }

            // set the player cstom button(grid) collection list if it is placed on the right side of screen
            // Make two grids of buttons for each player one for defense and one for offense(Defense buttons wnot have click events)
            for (int grids = 0; grids < 2; grids++)
            {
                // determine the grid type and assign a flag to the buttons if they are defense or offense.
                if (grids == 0)
                {
                    // will iterate the number of columns requested
                    for (int col = 0; col < maxCol; col++)
                    {
                        // will iterate the number of rows(same as the columns) requested
                        for (int row = 0; row < maxCol; row++)
                        {
                            // create a name for this button will result in a string(10.0001, this is elevated to the ten thounsans to allow a high number of buttons without the repeating of the name)
                            double rowthousand = col + 1 + ((row + 1) * 0.0001);

                            GridCell myButton = new GridCell(player_ID, buttoncolorForDeffense, rowthousand.ToString(), this);
                            myButton.Content = capital_letters[col] + (row + 1);
                            myButton.TrackingID = (col + 1) + (row * maxCol);
                            myButton.Width = gridcellSize;
                            myButton.Height = gridcellSize;
                            myButton.RowNum = row + 1;
                            myButton.ColNum = col + 1;
                            myButton.OffenseButton = false;
                            myButton.AllowDrop = true;
                            myButton.Buttonid = (col * 10) + row;
                            myButton.Uid = capital_letters[col] + (row + 1); // will result in an id(A1) string
                            Canvas.SetTop(myButton, row * gridcellSize); // assign a value where it will be loaded if plased on a canvas
                            Canvas.SetLeft(myButton, col * gridcellSize); // assign a value where it will be loaded if plased on a canvas
                            myButton.Left_Comp_ParentLeft = col * gridcellSize;
                            myButton.Top_Comp_ParentTop = row * gridcellSize;
                            playerGridCellsComputer.Add(col + 1 + (row * maxCol), myButton);
                        }
                    }
                }
                else
                {
                    // second iteration for creating the attack grid
                    // offset this buttons from the left to become the attack grid to compaensate the space occupied by the defense grid
                    double gridOffsetWhenVisual = gridcellSize * maxCol;

                    // will iterate the number of columns requested
                    for (int col = 0; col < maxCol; col++)
                    {
                        // will iterate the number of rows(same as the columns) requested
                        for (int row = 0; row < maxCol; row++)
                        {
                            // create a name for this button will result in a string(10.0001, this is elevated to the ten thounsans to allow a high number of buttons without the repeating of the name)
                            double rowthousand = col + 1 + ((row + 1) * 0.0001);
                            int dictionaryOffset = maxCol * maxCol;
                            GridCell myButton = new GridCell(player_ID, buttoncolorForOffense, rowthousand.ToString(), this);
                            myButton.Content = capital_letters[col] + (row + 1);
                            myButton.TrackingID = col + 1 + (row * maxCol);
                            myButton.Width = gridcellSize;
                            myButton.Height = gridcellSize;
                            myButton.RowNum = row + 1;
                            myButton.ColNum = col + 1;
                            myButton.OffenseButton = true;
                            myButton.AllowDrop = false;
                            myButton.Buttonid = (col * 10) + row;
                            myButton.Uid = capital_letters[col] + (row + 1); // will result in an id(A1) string
                            Canvas.SetTop(myButton, row * gridcellSize); // assign a value where it will be loaded if plased on a canvas
                            Canvas.SetLeft(myButton, (col * gridcellSize) + gridOffsetWhenVisual); // assign a value where it will be loaded if plased on a canvas
                            playerGridCellsComputer.Add(dictionaryOffset + col + 1 + (row * maxCol), myButton);
                        }
                    }
                }
            }

            // load the button collection to the list field if it is right
            this.playerGridCells = playerGridCellsComputer;

            if (difficulty == StatusCodes.ComputerPlayerDifficulty.COMPUTER_DIFFICULTY_EASY)
            {
                this.playerShips = this.RandomShipPlacement(player_ID, gridcellSize, maxCol, shiploader);
            }
            else
            {
                this.playerShips = this.AdvancedShipPlacement(player_ID, gridcellSize, maxCol, shiploader);
            }

            foreach (Ship warship in this.playerShips)
            {
                BitmapImage shipPic = new BitmapImage();
                shipPic.BeginInit();
                shipPic.UriSource = new Uri(@"./Images/Warship.jpg", UriKind.Relative);
                shipPic.EndInit();

                warship.Background = new ImageBrush(shipPic);
                warship.Uid = warship.ShipType.ToString();
                Canvas.SetTop(warship, (warship.ShipStartCoords.YCoordinate - 1) * gridcellSize);
                Canvas.SetLeft(warship, (warship.ShipStartCoords.XCoordinate - 1) * gridcellSize);

                warship.OnShipIsSunk += this.PlayerShipSunk;
            }
        }

        /// <summary>
        ///  Gets a computer player difficulty.
        /// </summary>
        public StatusCodes.ComputerPlayerDifficulty Difficulty
        {
            get { return this.difficulty; }
        }

        /// <summary>
        /// Advanced attacking of computer player.
        /// </summary>
        /// <param name="p_otherPlayer">The enemy player.</param>
        /// <param name="rowRep">The number of columns and rows.</param>
        public void AdvancedAttack(Player p_otherPlayer, int rowRep)
        {
            if (this.hitList.Count == 0)
            {
                Random random = new Random();
                Coordinate position = new Coordinate();
                bool availableToChoose = false;

                int rowNumber = 0;
                int colNumber = 0;

                while (!availableToChoose)
                {
                    rowNumber = random.Next(0, 10);
                    colNumber = random.Next(0, 10);
                    string letterAttackGrid = p_otherPlayer.Board[rowNumber, colNumber];

                    if (letterAttackGrid != "H" && letterAttackGrid != "M")
                    {
                        GridCell playerCell = this.playerGridCells[((rowNumber * 10) + (colNumber + 1)) + 100];
                        if (letterAttackGrid == "O")
                        {
                            if (this.GridSearch(rowNumber, colNumber))
                            {
                                availableToChoose = true;
                                p_otherPlayer.Board[rowNumber, colNumber] = "M";
                                this.attackedList.Add((rowNumber * 10) + colNumber);
                                playerCell.Visibility = Visibility.Hidden;
                            }
                        }
                        else
                        {
                            availableToChoose = true;
                            this.attackShipName = p_otherPlayer.Board[rowNumber, colNumber];
                            foreach (Ship testShip in p_otherPlayer.Playershipcollection)
                            {
                                if (this.attackShipName == testShip.ShipName.Substring(0, 2))
                                {
                                    this.attackShipLength = testShip.Length;
                                }
                            }

                            p_otherPlayer.Board[rowNumber, colNumber] = "H";
                            playerCell.Background = Brushes.Green;
                            playerCell.Content = "H";
                            playerCell.Stricked = 1;
                            playerCell.AllowDrop = false;
                            this.AddNeighborGrids((rowNumber * 10) + colNumber);
                            this.prevGrid = (rowNumber * 10) + colNumber;
                            this.alreadyAttackedGrids.Add((rowNumber * 10) + colNumber);
                            this.allow = true;
                            this.attackedList.Add((rowNumber * 10) + colNumber);
                        }
                    }
                }

                position.XCoordinate = (short)colNumber;
                position.YCoordinate = (short)rowNumber;

                Logger.ConsoleInformation("------- Player Grid ------");
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Logger.ConsoleInformationForArray(p_otherPlayer.Board[i, j] + ", ");
                    }

                    Logger.ConsoleInformation("\n");
                }

                Logger.ConsoleInformation(position.XCoordinate.ToString() + ' ' + position.YCoordinate.ToString());
                foreach (KeyValuePair<int, GridCell> playerPair in p_otherPlayer.Playergridsquarecollection)
                {
                    GridCell playerCell = playerPair.Value;
                    int y = ((position.YCoordinate + 1) * 10) + (position.XCoordinate + 1);
                    if (playerPair.Key == (position.YCoordinate * 10) + (position.XCoordinate + 1) &&
                        playerCell.OffenseButton == false)
                    {
                        // make changes to player two grid
                        playerCell.Background = Brushes.Red;
                        playerCell.Content = "X";
                        playerCell.Stricked = 1;
                        playerCell.AllowDrop = false;
                    }
                }

                Coordinate attackedGridSpace = new Coordinate((short)(position.XCoordinate + 1), (short)(position.YCoordinate + 1));

                foreach (Ship testShip in p_otherPlayer.Playershipcollection)
                {
                    // Logger.Information(testShip.ShipStartCoords.XCoordinate.ToString() + " "+ testShip.ShipStartCoords.YCoordinate.ToString());
                    AttackCoordinate tempCoordainte = testShip.AttackGridSpace(attackedGridSpace);
                }

                Logger.ConsoleInformation("------- Computer99 Grid ------");
                for (int i = 0; i < rowRep; i++)
                {
                    for (int j = 0; j < rowRep; j++)
                    {
                        Logger.ConsoleInformationForArray(this.Board[i, j] + ", ");
                    }

                    Logger.ConsoleInformation("\n");
                }
            }
            else
            {
                Coordinate position = new Coordinate();
                bool availableToChoose = false;
                int k = 0;
                bool findGridInDirection = false;

                if (this.allow)
                {
                    int rowNumber = this.hitList[k] / 10;
                    int colNumber = this.hitList[k] % 10;

                    while (!availableToChoose)
                    {
                        string letterAttackGrid = p_otherPlayer.Board[rowNumber, colNumber];

                        if (letterAttackGrid != "H" && letterAttackGrid != "M")
                        {
                            availableToChoose = true;
                            GridCell playerCell = this.playerGridCells[((rowNumber * 10) + (colNumber + 1)) + 100];
                            if (letterAttackGrid == "O")
                            {
                                p_otherPlayer.Board[rowNumber, colNumber] = "M";
                                playerCell.Visibility = Visibility.Hidden;
                                this.hitList.RemoveAt(k);
                                this.attackedList.Add((rowNumber * 10) + colNumber);
                            }
                            else
                            {
                                if (p_otherPlayer.Board[rowNumber, colNumber] == this.attackShipName)
                                {
                                    this.attackShipLength--;
                                }

                                if ((this.prevGrid / 10) == rowNumber)
                                {
                                    this.attackShipDirection = true;
                                    this.allow = false;
                                }
                                else
                                {
                                    this.attackShipDirection = false;
                                    this.allow = false;
                                }

                                p_otherPlayer.Board[rowNumber, colNumber] = "H";
                                playerCell.Background = Brushes.Green;
                                playerCell.Content = "H";
                                playerCell.Stricked = 1;
                                playerCell.AllowDrop = false;
                                this.AddNeighborGrids((rowNumber * 10) + colNumber);
                                this.alreadyAttackedGrids.Add((rowNumber * 10) + colNumber);
                                this.hitList.RemoveAt(k);
                                this.attackedList.Add((rowNumber * 10) + colNumber);
                            }
                        }
                        else
                        {
                            this.hitList.RemoveAt(k);
                            break;
                        }
                    }

                    if (this.attackShipLength == 1)
                    {
                        this.hitList.Clear();
                        this.alreadyAttackedGrids.Clear();
                    }

                    position.XCoordinate = (short)colNumber;
                    position.YCoordinate = (short)rowNumber;

                    Logger.ConsoleInformation("------- Player Grid ------");
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            Logger.ConsoleInformationForArray(p_otherPlayer.Board[i, j] + ", ");
                        }

                        Logger.ConsoleInformation("\n");
                    }

                    Logger.ConsoleInformation(position.XCoordinate.ToString() + ' ' + position.YCoordinate.ToString());
                    foreach (KeyValuePair<int, GridCell> playerPair in p_otherPlayer.Playergridsquarecollection)
                    {
                        GridCell playerCell = playerPair.Value;
                        int y = ((position.YCoordinate + 1) * 10) + (position.XCoordinate + 1);
                        if (playerPair.Key == (position.YCoordinate * 10) + (position.XCoordinate + 1) && playerCell.OffenseButton == false)
                        {
                            // make changes to player two grid
                            playerCell.Background = Brushes.Red;
                            playerCell.Content = "X";
                            playerCell.Stricked = 1;
                            playerCell.AllowDrop = false;
                        }
                    }

                    Coordinate attackedGridSpace = new Coordinate((short)(position.XCoordinate + 1), (short)(position.YCoordinate + 1));

                    foreach (Ship testShip in p_otherPlayer.Playershipcollection)
                    {
                        // Logger.Information(testShip.ShipStartCoords.XCoordinate.ToString() + " "+ testShip.ShipStartCoords.YCoordinate.ToString());
                        AttackCoordinate tempCoordainte = testShip.AttackGridSpace(attackedGridSpace);
                    }

                    Logger.ConsoleInformation("------- Computer99 Grid ------");
                    for (int i = 0; i < rowRep; i++)
                    {
                        for (int j = 0; j < rowRep; j++)
                        {
                            Logger.ConsoleInformationForArray(this.Board[i, j] + ", ");
                        }

                        Logger.ConsoleInformation("\n");
                    }
                }
                else
                {
                    while (!findGridInDirection)
                    {
                        int rowNumber = this.hitList[k] / 10;
                        int colNumber = this.hitList[k] % 10;
                        bool check = true;
                        foreach (int gridSquare in this.alreadyAttackedGrids)
                        {
                            if (gridSquare == this.hitList[k])
                            {
                                check = false;
                                break;
                            }
                        }

                        if (this.attackShipDirection && (this.prevGrid / 10) == rowNumber && check)
                        {
                            findGridInDirection = true;
                            while (!availableToChoose)
                            {
                                string letterAttackGrid = p_otherPlayer.Board[rowNumber, colNumber];

                                if (letterAttackGrid != "H" && letterAttackGrid != "M")
                                {
                                    availableToChoose = true;
                                    GridCell playerCell =
                                        this.playerGridCells[((rowNumber * 10) + (colNumber + 1)) + 100];
                                    if (letterAttackGrid == "O")
                                    {
                                        p_otherPlayer.Board[rowNumber, colNumber] = "M";
                                        playerCell.Visibility = Visibility.Hidden;
                                        this.hitList.RemoveAt(k);
                                        this.attackedList.Add((rowNumber * 10) + colNumber);
                                    }
                                    else
                                    {
                                        if (p_otherPlayer.Board[rowNumber, colNumber] == this.attackShipName)
                                        {
                                            this.attackShipLength--;
                                        }

                                        if ((this.prevGrid / 10) == rowNumber)
                                        {
                                            this.attackShipDirection = true;
                                        }
                                        else
                                        {
                                            this.attackShipDirection = false;
                                        }

                                        p_otherPlayer.Board[rowNumber, colNumber] = "H";
                                        playerCell.Background = Brushes.Green;
                                        playerCell.Content = "H";
                                        playerCell.Stricked = 1;
                                        playerCell.AllowDrop = false;
                                        this.AddNeighborGrids((rowNumber * 10) + colNumber);
                                        this.alreadyAttackedGrids.Add((rowNumber * 10) + colNumber);
                                        this.hitList.RemoveAt(k);
                                        this.attackedList.Add((rowNumber * 10) + colNumber);
                                    }
                                }
                                else
                                {
                                    this.hitList.RemoveAt(k);
                                    break;
                                }
                            }

                            if (this.attackShipLength == 1)
                            {
                                this.hitList.Clear();
                                this.alreadyAttackedGrids.Clear();
                            }

                            position.XCoordinate = (short)colNumber;
                            position.YCoordinate = (short)rowNumber;

                            Logger.ConsoleInformation("------- Player Grid ------");
                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    Logger.ConsoleInformationForArray(p_otherPlayer.Board[i, j] + ", ");
                                }

                                Logger.ConsoleInformation("\n");
                            }

                            Logger.ConsoleInformation(position.XCoordinate.ToString() + ' ' + position.YCoordinate.ToString());
                            foreach (KeyValuePair<int, GridCell> playerPair in p_otherPlayer.Playergridsquarecollection)
                            {
                                GridCell playerCell = playerPair.Value;
                                int y = ((position.YCoordinate + 1) * 10) + (position.XCoordinate + 1);
                                if (playerPair.Key == (position.YCoordinate * 10) + (position.XCoordinate + 1) &&
                                    playerCell.OffenseButton == false)
                                {
                                    // make changes to player two grid
                                    playerCell.Background = Brushes.Red;
                                    playerCell.Content = "X";
                                    playerCell.Stricked = 1;
                                    playerCell.AllowDrop = false;
                                }
                            }

                            Coordinate attackedGridSpace = new Coordinate((short)(position.XCoordinate + 1), (short)(position.YCoordinate + 1));

                            foreach (Ship testShip in p_otherPlayer.Playershipcollection)
                            {
                                // Logger.Information(testShip.ShipStartCoords.XCoordinate.ToString() + " "+ testShip.ShipStartCoords.YCoordinate.ToString());
                                AttackCoordinate tempCoordainte = testShip.AttackGridSpace(attackedGridSpace);
                            }

                            Logger.ConsoleInformation("------- Computer99 Grid ------");
                            for (int i = 0; i < rowRep; i++)
                            {
                                for (int j = 0; j < rowRep; j++)
                                {
                                    Logger.ConsoleInformationForArray(this.Board[i, j] + ", ");
                                }

                                Logger.ConsoleInformation("\n");
                            }
                        }
                        else if (!this.attackShipDirection && (this.prevGrid % 10) == colNumber && check)
                        {
                            findGridInDirection = true;
                            while (!availableToChoose)
                            {
                                string letterAttackGrid = p_otherPlayer.Board[rowNumber, colNumber];

                                if (letterAttackGrid != "H" && letterAttackGrid != "M")
                                {
                                    availableToChoose = true;
                                    GridCell playerCell =
                                        this.playerGridCells[((rowNumber * 10) + (colNumber + 1)) + 100];
                                    if (letterAttackGrid == "O")
                                    {
                                        p_otherPlayer.Board[rowNumber, colNumber] = "M";
                                        playerCell.Visibility = Visibility.Hidden;
                                        this.hitList.RemoveAt(k);
                                        this.attackedList.Add((rowNumber * 10) + colNumber);
                                    }
                                    else
                                    {
                                        if (p_otherPlayer.Board[rowNumber, colNumber] == this.attackShipName)
                                        {
                                            this.attackShipLength--;
                                        }

                                        if ((this.prevGrid / 10) == rowNumber)
                                        {
                                            this.attackShipDirection = true;
                                        }
                                        else
                                        {
                                            this.attackShipDirection = false;
                                        }

                                        p_otherPlayer.Board[rowNumber, colNumber] = "H";
                                        playerCell.Background = Brushes.Green;
                                        playerCell.Content = "H";
                                        playerCell.Stricked = 1;
                                        playerCell.AllowDrop = false;
                                        this.AddNeighborGrids((rowNumber * 10) + colNumber);
                                        this.hitList.RemoveAt(k);
                                        this.attackedList.Add((rowNumber * 10) + colNumber);
                                    }
                                }
                                else
                                {
                                    this.hitList.RemoveAt(k);
                                    break;
                                }
                            }

                            if (this.attackShipLength == 1)
                            {
                                this.hitList.Clear();
                            }

                            position.XCoordinate = (short)colNumber;
                            position.YCoordinate = (short)rowNumber;

                            Logger.ConsoleInformation("------- Player Grid ------");
                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    Logger.ConsoleInformationForArray(p_otherPlayer.Board[i, j] + ", ");
                                }

                                Logger.ConsoleInformation("\n");
                            }

                            Logger.ConsoleInformation(position.XCoordinate.ToString() + ' ' + position.YCoordinate.ToString());
                            foreach (KeyValuePair<int, GridCell> playerPair in p_otherPlayer.Playergridsquarecollection)
                            {
                                GridCell playerCell = playerPair.Value;
                                int y = ((position.YCoordinate + 1) * 10) + (position.XCoordinate + 1);
                                if (playerPair.Key == (position.YCoordinate * 10) + (position.XCoordinate + 1) &&
                                    playerCell.OffenseButton == false)
                                {
                                    // make changes to player two grid
                                    playerCell.Background = Brushes.Red;
                                    playerCell.Content = "X";
                                    playerCell.Stricked = 1;
                                    playerCell.AllowDrop = false;
                                }
                            }

                            Coordinate attackedGridSpace = new Coordinate((short)(position.XCoordinate + 1), (short)(position.YCoordinate + 1));

                            foreach (Ship testShip in p_otherPlayer.Playershipcollection)
                            {
                                // Logger.Information(testShip.ShipStartCoords.XCoordinate.ToString() + " "+ testShip.ShipStartCoords.YCoordinate.ToString());
                                AttackCoordinate tempCoordainte = testShip.AttackGridSpace(attackedGridSpace);
                            }

                            Logger.ConsoleInformation("------- Computer99 Grid ------");
                            for (int i = 0; i < rowRep; i++)
                            {
                                for (int j = 0; j < rowRep; j++)
                                {
                                    Logger.ConsoleInformationForArray(this.Board[i, j] + ", ");
                                }

                                Logger.ConsoleInformation("\n");
                            }
                        }
                        else
                        {
                            this.hitList.RemoveAt(k);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method in which the computer attacks.
        /// </summary>
        /// <param name="p_otherPlayer">The other player being attacked.</param>
        /// <param name="rowRep">The grid space being attacked.</param>
        public void CompPlayerAttack(Player p_otherPlayer, int rowRep)
        {
            Coordinate position = this.SetRandomAttackCoordinate(p_otherPlayer);
            Logger.ConsoleInformation(position.XCoordinate.ToString() + ' ' + position.YCoordinate.ToString());
            foreach (KeyValuePair<int, GridCell> playerPair in p_otherPlayer.Playergridsquarecollection)
            {
                GridCell playerCell = playerPair.Value;
                int y = ((position.YCoordinate + 1) * 10) + (position.XCoordinate + 1);
                if (playerPair.Key == (position.YCoordinate * 10) + (position.XCoordinate + 1) &&
                    playerCell.OffenseButton == false)
                {
                    // make changes to player two grid
                    playerCell.Background = Brushes.Red;
                    playerCell.Content = "X";
                    playerCell.Stricked = 1;
                    playerCell.AllowDrop = false;
                }
            }

            Coordinate attackedGridSpace = new Coordinate((short)(position.XCoordinate + 1), (short)(position.YCoordinate + 1));

            foreach (Ship testShip in p_otherPlayer.Playershipcollection)
            {
                // Logger.Information(testShip.ShipStartCoords.XCoordinate.ToString() + " "+ testShip.ShipStartCoords.YCoordinate.ToString());
                AttackCoordinate tempCoordainte = testShip.AttackGridSpace(attackedGridSpace);
            }

            Logger.ConsoleInformation("------- Computer Grid ------");
            for (int i = 0; i < rowRep; i++)
            {
                for (int j = 0; j < rowRep; j++)
                {
                    Logger.ConsoleInformationForArray(this.Board[i, j] + ", ");
                }

                Logger.ConsoleInformation("\n");
            }
        }

        /// <summary>
        /// Method to retrieve a random attack coordinate.
        /// </summary>
        /// <param name="p_otherPlayer">The other player being attacked.</param>
        /// <returns>The coordinate being attacked.</returns>
        public Coordinate SetRandomAttackCoordinate(Player p_otherPlayer)
        {
            Random random = new Random();
            Coordinate position = new Coordinate();
            bool availableToChoose = false;

            int rowNumber = 0;
            int colNumber = 0;

            while (!availableToChoose)
            {
                rowNumber = random.Next(0, 10);
                colNumber = random.Next(0, 10);
                string letterAttackGrid = p_otherPlayer.Board[rowNumber, colNumber];

                if (letterAttackGrid != "H" | letterAttackGrid != "M")
                {
                    availableToChoose = true;
                    GridCell playerCell = this.playerGridCells[((rowNumber * 10) + (colNumber + 1)) + 100];
                    if (letterAttackGrid == "O")
                    {
                        p_otherPlayer.Board[rowNumber, colNumber] = "M";
                        playerCell.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        p_otherPlayer.Board[rowNumber, colNumber] = "H";
                        playerCell.Background = Brushes.Green;
                        playerCell.Content = "H";
                        playerCell.Stricked = 1;
                        playerCell.AllowDrop = false;
                    }
                }
            }

            position.XCoordinate = (short)colNumber;
            position.YCoordinate = (short)rowNumber;

            Logger.ConsoleInformation("------- Player Grid ------");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Logger.ConsoleInformationForArray(p_otherPlayer.Board[i, j] + ", ");
                }

                Logger.ConsoleInformation("\n");
            }

            return position;
        }

        /// <summary>
        /// Method that searches the grid for information.
        /// </summary>
        /// <param name="rowNumber">The row number of the grid space.</param>
        /// <param name="colNumber">The column number of the grid space.</param>
        /// <returns>Whether or not the grid space is occupied.</returns>
        private bool GridSearch(int rowNumber, int colNumber)
        {
            int gridNumber = (rowNumber * 10) + colNumber;
            bool allowToPlace = true;
            if (gridNumber % 10 == 0)
            {
                foreach (int grid in this.attackedList)
                {
                    if (grid == (gridNumber + 1))
                    {
                        allowToPlace = false;
                        break;
                    }
                }
            }
            else if (gridNumber % 10 == 9)
            {
                foreach (int grid in this.attackedList)
                {
                    if (grid == (gridNumber - 1))
                    {
                        allowToPlace = false;
                        break;
                    }
                }
            }
            else
            {
                foreach (int grid in this.attackedList)
                {
                    if (grid == (gridNumber - 1) || grid == (gridNumber + 1))
                    {
                        allowToPlace = false;
                        break;
                    }
                }
            }

            if (gridNumber < 10)
            {
                foreach (int grid in this.attackedList)
                {
                    if (grid == (gridNumber + 10))
                    {
                        allowToPlace = false;
                        break;
                    }
                }
            }
            else if (gridNumber > 89)
            {
                foreach (int grid in this.attackedList)
                {
                    if (grid == (gridNumber - 10))
                    {
                        allowToPlace = false;
                        break;
                    }
                }
            }
            else
            {
                foreach (int grid in this.attackedList)
                {
                    if (grid == (gridNumber - 10) || grid == (gridNumber + 10))
                    {
                        allowToPlace = false;
                        break;
                    }
                }
            }

            return allowToPlace;
        }

        /// <summary>
        /// Method that adds neighbor grids.
        /// </summary>
        /// <param name="gridNumber">The grid number to be added.</param>
        private void AddNeighborGrids(int gridNumber)
        {
            if (this.attackShipLength == 0)
            {
                this.hitList.Clear();
            }
            else
            {
                if (gridNumber % 10 == 0)
                {
                    this.hitList.Add(gridNumber + 1);
                }
                else if (gridNumber % 10 == 9)
                {
                    this.hitList.Add(gridNumber - 1);
                }
                else
                {
                    this.hitList.Add(gridNumber + 1);
                    this.hitList.Add(gridNumber - 1);
                }

                if (gridNumber < 10)
                {
                    this.hitList.Add(gridNumber + 10);
                }
                else if (gridNumber > 89)
                {
                    this.hitList.Add(gridNumber - 10);
                }
                else
                {
                    this.hitList.Add(gridNumber + 10);
                    this.hitList.Add(gridNumber - 10);
                }
            }
        }

        /// <summary>
        /// Method that randomly-places ships.
        /// </summary>
        /// <param name="player_ID">The ID of the player.</param>
        /// <param name="gridcellSize">The size of each grid space (in pixels).</param>
        /// <param name="maxCol">The maximum number of columns.</param>
        /// <param name="shiploader">The ship to be loaded.</param>
        /// <returns>The list of ships that are loaded.</returns>
        private List<Ship> RandomShipPlacement(int player_ID, double gridcellSize, int maxCol, List<Ship> shiploader)
        {
            bool horDirection;
            Coordinate position = new Coordinate();

            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                if (random.Next(1, 3) == 1)
                {
                    horDirection = true;
                }
                else
                {
                    horDirection = false;
                }

                Ship warship = new Ship(player_ID, i, gridcellSize, horDirection);

                Coordinate shipPosition = new Coordinate();
                shipPosition = this.SetRandomShipCoordinate(warship, maxCol, horDirection);
                int rowShip = shipPosition.YCoordinate;
                int colShip = shipPosition.XCoordinate;
                Coordinate shipPositionFinal = new Coordinate((short)(shipPosition.XCoordinate + 1), (short)(shipPosition.YCoordinate + 1));
                warship.ShipStartCoords = shipPositionFinal;
                for (int j = 0; j < warship.Length; j++)
                {
                    string letter = warship.ShipName.Substring(0, 2);
                    this.board[rowShip, colShip] = letter;
                    if (horDirection)
                    {
                        colShip++;
                    }
                    else
                    {
                        rowShip++;
                    }
                }

                // load the ship to the list of ships
                shiploader.Add(warship);
            }

            return shiploader;
        }

        /// <summary>
        /// The random ship coordinate.
        /// </summary>
        /// <param name="warship">The ship to be randomly-placed.</param>
        /// <param name="maxCol">The maximum number of column spaces.</param>
        /// <param name="horDirection">Whether or not the ship is horizontal.</param>
        /// <returns>The coordinate to place the ship in.</returns>
        private Coordinate SetRandomShipCoordinate(Ship warship, int maxCol, bool horDirection)
        {
            Random random = new Random();
            Coordinate position = new Coordinate();
            bool availableToPlace = false;

            int rowNumber;
            int colNumber;

            while (!availableToPlace)
            {
                rowNumber = random.Next(0, 10);
                colNumber = random.Next(0, 10);

                int tempRow = rowNumber;
                int tempCol = colNumber;

                int checks = 0;
                for (int j = 0; j < warship.Length; j++)
                {
                    if (horDirection)
                    {
                        if (tempCol <= (maxCol - 1))
                        {
                            if (this.board[rowNumber, tempCol] == "O")
                            {
                                checks++;
                                tempCol++;
                            }
                            else
                            {
                                availableToPlace = false;
                                break;
                            }
                        }
                        else
                        {
                            availableToPlace = false;
                            break;
                        }
                    }
                    else
                    {
                        if (tempRow <= (maxCol - 1))
                        {
                            if (this.board[tempRow, colNumber] == "O")
                            {
                                checks++;
                                tempRow++;
                            }
                            else
                            {
                                availableToPlace = false;
                                break;
                            }
                        }
                        else
                        {
                            availableToPlace = false;
                            break;
                        }
                    }
                }

                if (checks == warship.Length)
                {
                    availableToPlace = true;
                    position.XCoordinate = (short)colNumber;
                    position.YCoordinate = (short)rowNumber;
                }
            }

            return position;
        }

        /// <summary>
        /// Places the ships randomly in an advanced way.
        /// </summary>
        /// <param name="player_ID">The ID of the player.</param>
        /// <param name="gridcellSize">The grid cell size (in pixels).</param>
        /// <param name="maxCol">The maximum number of columns.</param>
        /// <param name="shiploader">The list of ships to be randomly-placed.</param>
        /// <returns>The list of ships after they are randomly-placed.</returns>
        private List<Ship> AdvancedShipPlacement(int player_ID, double gridcellSize, int maxCol, List<Ship> shiploader)
        {
            bool horDirection;
            Coordinate position = new Coordinate();
            List<Ship> tempShips = new List<Ship>();

            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                if (random.Next(1, 3) == 1)
                {
                    horDirection = true;
                }
                else
                {
                    horDirection = false;
                }

                Ship warship = new Ship(player_ID, i, gridcellSize, horDirection);
                tempShips.Add(warship);
            }

            int shipIndex1 = random.Next(0, 5);
            this.SetShipOnEdge(tempShips[shipIndex1], maxCol);
            this.SetToBoard(tempShips[shipIndex1]);
            bool compare = true;
            int shipIndex2 = 0;
            while (compare)
            {
                shipIndex2 = random.Next(0, 5);
                if (shipIndex2 != shipIndex1)
                {
                    this.SetShipOnEdge(tempShips[shipIndex2], maxCol);
                    this.SetToBoard(tempShips[shipIndex2]);
                    compare = false;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (i != shipIndex1 && i != shipIndex2)
                {
                    Coordinate shipPosition = this.SetRandomShipCoordinate(tempShips[i], maxCol, tempShips[i].HDirection);
                    int rowShip = shipPosition.YCoordinate;
                    int colShip = shipPosition.XCoordinate;
                    Coordinate shipPositionFinal = new Coordinate((short)(shipPosition.XCoordinate + 1), (short)(shipPosition.YCoordinate + 1));
                    tempShips[i].ShipStartCoords = shipPositionFinal;
                    this.SetToBoard(tempShips[i]);
                }
            }

            shiploader = tempShips;

            return shiploader;
        }

        /// <summary>
        /// Method to set the board.
        /// </summary>
        /// <param name="warship">The ship to be placed on the board.</param>
        private void SetToBoard(Ship warship)
        {
            int colShip = warship.ShipStartCoords.XCoordinate - 1;
            int rowShip = warship.ShipStartCoords.YCoordinate - 1;
            for (int j = 0; j < warship.Length; j++)
            {
                string letter = warship.ShipName.Substring(0, 2);
                this.board[rowShip, colShip] = letter;
                if (warship.HDirection)
                {
                    colShip++;
                }
                else
                {
                    rowShip++;
                }
            }
        }

        /// <summary>
        /// Method to set the ship on the edge of the board.
        /// </summary>
        /// <param name="testShip">The ship to be tested.</param>
        /// <param name="maxCol">The maximum number of columns.</param>
        private void SetShipOnEdge(Ship testShip, int maxCol)
        {
            Random rand = new Random();
            int rowNum;
            int colNum;
            bool checking = false;

            while (!checking)
            {
                int side = rand.Next(0, 4);
                if (testShip.HDirection && side == 1)
                {
                    checking = true;
                    bool availableToPlace = false;
                    rowNum = 0;
                    while (!availableToPlace)
                    {
                        colNum = rand.Next(0, 10);
                        int tempCol = colNum;

                        int checks = 0;
                        for (int j = 0; j < testShip.Length; j++)
                        {
                            if (tempCol <= (maxCol - 1))
                            {
                                if (this.board[rowNum, tempCol] == "O")
                                {
                                    checks++;
                                    tempCol++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (checks == testShip.Length)
                        {
                            availableToPlace = true;
                            testShip.ShipStartCoords = new Coordinate((short)(colNum + 1), (short)(rowNum + 1));
                        }
                    }
                }
                else if (testShip.HDirection && side == 3)
                {
                    checking = true;
                    bool availableToPlace = false;
                    rowNum = 9;
                    while (!availableToPlace)
                    {
                        colNum = rand.Next(0, 10);
                        int tempCol = colNum;

                        int checks = 0;
                        for (int j = 0; j < testShip.Length; j++)
                        {
                            if (tempCol <= (maxCol - 1))
                            {
                                if (this.board[rowNum, tempCol] == "O")
                                {
                                    checks++;
                                    tempCol++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (checks == testShip.Length)
                        {
                            availableToPlace = true;
                            testShip.ShipStartCoords = new Coordinate((short)(colNum + 1), (short)(rowNum + 1));
                        }
                    }
                }
                else if (!testShip.HDirection && side == 0)
                {
                    checking = true;
                    bool availableToPlace = false;
                    colNum = 0;
                    while (!availableToPlace)
                    {
                        rowNum = rand.Next(0, 10);
                        int tempRow = rowNum;

                        int checks = 0;
                        for (int j = 0; j < testShip.Length; j++)
                        {
                            if (tempRow <= (maxCol - 1))
                            {
                                if (this.board[rowNum, tempRow] == "O")
                                {
                                    checks++;
                                    tempRow++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (checks == testShip.Length)
                        {
                            availableToPlace = true;
                            testShip.ShipStartCoords = new Coordinate((short)(colNum + 1), (short)(rowNum + 1));
                        }
                    }
                }
                else if (!testShip.HDirection && side == 2)
                {
                    checking = true;
                    bool availableToPlace = false;
                    colNum = 9;
                    while (!availableToPlace)
                    {
                        rowNum = rand.Next(0, 10);
                        int tempRow = rowNum;

                        int checks = 0;
                        for (int j = 0; j < testShip.Length; j++)
                        {
                            if (tempRow <= (maxCol - 1))
                            {
                                if (this.board[rowNum, tempRow] == "O")
                                {
                                    checks++;
                                    tempRow++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (checks == testShip.Length)
                        {
                            availableToPlace = true;
                            testShip.ShipStartCoords = new Coordinate((short)(colNum + 1), (short)(rowNum + 1));
                        }
                    }
                }
            }
        }
    }
}
