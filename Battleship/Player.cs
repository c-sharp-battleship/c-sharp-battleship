//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
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

    /// <summary>
    /// Interaction logic for Player. This class is a canvas that will load with a list of grid squares and a list of ships attached as a property
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The player's ID.
        /// </summary>
        private int playerID;

        /// <summary>
        /// The player's name.
        /// </summary>
        private string name;

        /// <summary>
        /// The list of player's ships.
        /// </summary>
        private List<Ship> playerShips;

        /// <summary>
        /// The list of player's gris cells.
        /// </summary>
        private List<GridCell> playerGridCells;

        private string[,] board;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="player_ID"> This is the ID of the player </param>
        /// <param name="player_Name"> this is the name of the Player</param>
        /// <param name="gridcellSize"> This is the size in pixels for the grid square dimension</param>
        /// <param name="maxCol"> This is the max number of columns requested at the moment pf loading</param>
        /// <param name="buttoncolorForDeffense"> this is the color for the button created, refer to Custom button class(switch case in constructor)</param>
        /// <param name="buttoncolorForOffense"> This is the side of the screen to load the canvas, if left then reversed count, if right then incremental from one</param>
        public Player(int player_ID, string player_Name, double gridcellSize, int maxCol, int buttoncolorForDeffense, int buttoncolorForOffense)
        {
            // set the fixed properties
            this.name = player_Name;
            this.playerID = player_ID;

            // List of buttons for each player returned to the personal grid builder 
            List<GridCell> loader = new List<GridCell>();

            // List of ships for each player to return to the personal grid builder
            List<Ship> shiploader = new List<Ship>();

            // List of Alphabet letters to give names to gridcells
            string[] capital_letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            this.board = new string[maxCol, maxCol];

            for (int i = 0; i < maxCol; i++)
            {
                for(int j = 0; j < maxCol; j++)
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
                            if (grids == 0)
                            {
                                myButton.OffenseButton = false;
                                myButton.AllowDrop = true;
                            }
                            else
                            {
                                myButton.OffenseButton = true;
                                myButton.AllowDrop = false;
                            }
                            loader.Add(myButton);
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

                            GridCell myButton = new GridCell(player_ID, buttoncolorForOffense, rowthousand.ToString());
                            myButton.Content = capital_letters[col] + (row + 1);
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
                        }
                    }
                }
            }

            // load the button collection to the list field if it is right
            this.playerGridCells = loader;

            // Create a collection of 5 ships for any player 
            for (int i = 1; i <= 5; i++)
            {
                // get an iamge retainer for the iteration
                BitmapImage shipPic = new BitmapImage();
                shipPic.BeginInit();
                shipPic.UriSource = new Uri(@"./warship.jpg", UriKind.Relative);
                shipPic.EndInit();

                Coordinate startCoords = new Coordinate(1, (short)(i + 1));

                // Construct the ships with the image above
                Ship warship = new Ship(player_ID, 3, i, gridcellSize, startCoords);
                warship.Background = new ImageBrush(shipPic);
                warship.Uid = i.ToString();
                Canvas.SetTop(warship, i * gridcellSize);
                Canvas.SetLeft(warship, 0);

                warship.OnShipIsSunk += this.PlayerShipSunk;

                // load the ship to the list of ships
                shiploader.Add(warship);
            }
            //// Load the ships to the list passed down the line with the field
            this.playerShips = shiploader;
        }

        /// <summary>
        /// Gets player name 
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets player ID 
        /// </summary>
        public int PlayerID
        {
            get { return this.playerID; }
        }

        /// <summary>
        /// Gets player collection of ships 
        /// </summary>
        public List<Ship> Playershipcollection
        {
            get { return this.playerShips; }
        }

        /// <summary>
        /// Gets player Button collections for its personal grid 
        /// </summary>
        public List<GridCell> Playergridsquarecollection
        {
            get { return this.playerGridCells; }
        }

        public string[,] Board
        {
            get { return this.board; }
            set { this.board = value; }
        }

        /// <summary>
        /// Set a player ship sunk.
        /// </summary>
        /// <param name="sender">The object that initiated the event</param>
        /// <param name="e">The event arguments for the event.</param>
        private void PlayerShipSunk(object sender, EventArgs e)
        {
            Ship ship = sender as Ship;
            ship.ShipIsSunk = true;
            Logger.ConsoleInformation("Ship " + ship.Uid + " has been sunk!");

            this.CheckIfPlayerHasWon();
        }

        /// <summary>
        /// Set a method that checks if player has won.
        /// </summary>
        private void CheckIfPlayerHasWon()
        {
            int numberOfShipsThatHaveBeenSunk = 0;

            foreach (Ship ship in this.Playershipcollection)
            {
                if (ship.ShipIsSunk == true)
                {
                    numberOfShipsThatHaveBeenSunk++;
                }
            }

            if (numberOfShipsThatHaveBeenSunk == this.Playershipcollection.Count)
            {
                Logger.Information("You Have Won!");
            }
        }
    }
}
