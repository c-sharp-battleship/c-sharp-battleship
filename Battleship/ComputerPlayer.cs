//-----------------------------------------------------------------------
// <copyright file="ComputerPlayer.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Eventing.Reader;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for ComputerPlayer
    /// </summary>
    public class ComputerPlayer : Player
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="ComputerPlayer" /> class.
        /// </summary>
        /// <param name="player_ID"> This is the ID of the player </param>
        /// <param name="player_Name"> this is the name of the Player</param>
        /// <param name="gridcellSize"> This is the size in pixels for the grid square dimension</param>
        /// <param name="maxCol"> This is the max number of columns requested at the moment pf loading</param>
        /// <param name="buttoncolorForDeffense"> this is the color for the button created, refer to Custom button class(switch case in constructor)</param>
        /// <param name="buttoncolorForOffense"> This is the side of the screen to load the canvas, if left then reversed count, if right then incremental from one</param>
        public ComputerPlayer(int player_ID, string player_Name, double gridcellSize, int maxCol, int buttoncolorForDeffense, int buttoncolorForOffense) : base(player_ID, player_Name, gridcellSize, maxCol, buttoncolorForDeffense, buttoncolorForOffense)
        {
            // List of buttons for each player returned to the personal grid builder 
            List<GridCell> loader = new List<GridCell>();

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
                    board[i, j] = "O";
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

                            GridCell myButton = new GridCell(player_ID, buttoncolorForDeffense, rowthousand.ToString());
                            myButton.Content = capital_letters[col] + (row + 1);
                            myButton.TrackingID = (col + 1) + (row * maxCol);
                            myButton.Width = gridcellSize;
                            myButton.Height = gridcellSize;
                            myButton.RowNum = row + 1;
                            myButton.ColNum = col + 1;
                            myButton.OffenseButton = false;
                            myButton.AllowDrop = true;
                            myButton.Buttonid = col * 10 + row;
                            myButton.Uid = capital_letters[col] + (row + 1); // will result in an id(A1) string
                            Canvas.SetTop(myButton, row * gridcellSize); // assign a value where it will be loaded if plased on a canvas
                            Canvas.SetLeft(myButton, col * gridcellSize); // assign a value where it will be loaded if plased on a canvas
                            myButton.Left_Comp_ParentLeft = col * gridcellSize;
                            myButton.Top_Comp_ParentTop = row * gridcellSize;
                            
                            loader.Add(myButton);
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
                            int DictionaryOffset = maxCol * maxCol;
                            GridCell myButton = new GridCell(player_ID, buttoncolorForOffense, rowthousand.ToString());
                            myButton.Content = capital_letters[col] + (row + 1);
                            myButton.TrackingID = col + 1 + (row * maxCol);
                            myButton.Width = gridcellSize;
                            myButton.Height = gridcellSize;
                            myButton.RowNum = row + 1;
                            myButton.ColNum = col + 1;
                            myButton.OffenseButton = true;
                            myButton.AllowDrop = false;
                            myButton.Buttonid = col * 10 + row;
                            myButton.Uid = capital_letters[col] + (row + 1); // will result in an id(A1) string
                            Canvas.SetTop(myButton, row * gridcellSize); // assign a value where it will be loaded if plased on a canvas
                            Canvas.SetLeft(myButton, (col * gridcellSize) + gridOffsetWhenVisual); // assign a value where it will be loaded if plased on a canvas
                            loader.Add(myButton);
                            playerGridCellsComputer.Add(DictionaryOffset + col + 1 + (row * maxCol), myButton);
                        }
                    }
                }
            }

            // load the button collection to the list field if it is right
            this.playerGridCellsList = loader;
            this.playerGridCells = playerGridCellsComputer;

            this.playerShips = RandomShipPlacement(player_ID, gridcellSize, maxCol, shiploader);
            foreach (Ship warship in this.playerShips)
            {
                BitmapImage shipPic = new BitmapImage();
                shipPic.BeginInit();
                shipPic.UriSource = new Uri(@"./warship.jpg", UriKind.Relative);
                shipPic.EndInit();

                warship.Background = new ImageBrush(shipPic);
                warship.Uid = warship.ShipType.ToString();
                Canvas.SetTop(warship, (warship.ShipStartCoords.YCoordinate - 1) * gridcellSize);
                Canvas.SetLeft(warship, (warship.ShipStartCoords.XCoordinate - 1) * gridcellSize);

                warship.OnShipIsSunk += this.PlayerShipSunk;
            }
        }

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
                shipPosition = SetRandomShipCoordinate(warship, maxCol, horDirection);
                int rowShip = shipPosition.YCoordinate;
                int colShip = shipPosition.XCoordinate;
                Coordinate shipPositionFinal = new Coordinate((short) (shipPosition.XCoordinate + 1),
                    (short) (shipPosition.YCoordinate + 1));
                warship.ShipStartCoords = shipPositionFinal;
                for (int j = 0; j < warship.Length; j++)
                {
                    string letter = warship.Name.Substring(0, 2);
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
                    position.XCoordinate = (short) colNumber;
                    position.YCoordinate = (short) rowNumber;
                }
            }

            return position;
        }

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

                if (letterAttackGrid != "H" || letterAttackGrid != "M")
                {
                    availableToChoose = true;
                    if (letterAttackGrid == "O")
                    {
                        p_otherPlayer.Board[rowNumber, colNumber] = "M";
                    }
                    else
                    {
                        p_otherPlayer.Board[rowNumber, colNumber] = "H" + letterAttackGrid;
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

                Logger.ConsoleInformation("");
            }
            return position;
        }
    }
}
