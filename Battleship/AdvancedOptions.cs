//-----------------------------------------------------------------------
// <copyright file="AdvancedOptions.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System.Collections.Generic;

    /// <summary>
    /// Class to store the advanced options of the game.
    /// </summary>
    public class AdvancedOptions
    {
        /// <summary>
        /// Specifies how many ships each player's fleet should contain.
        /// </summary>
        private int fleetSize;

        /// <summary>
        /// The list containing the types of ships to be created (for a custom <see cref="fleetSize"/>.
        /// </summary>
        private List<StatusCodes.ShipType> shipTypes;

        /// <summary>
        /// Specifies the length and width of each board.
        /// </summary>
        private short gridSize;

        /// <summary>
        /// Determines whether or not the player can attack multiple times follow.
        /// </summary>
        private bool playerCanAttackAgain;

        /// <summary>
        /// Whether or not, during each turn, each player can get a hit based on the number of ships they have remaining.
        /// </summary>
        private bool eachShipGetsAShot;

        /// <summary>
        /// How many bombs a player may have per game.
        /// </summary>
        private int bombCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedOptions"/> class.
        /// </summary>
        public AdvancedOptions()
        {
            this.fleetSize = 5;

            this.shipTypes = new List<StatusCodes.ShipType>();

            this.shipTypes.Add(StatusCodes.ShipType.DESTROYER);
            this.shipTypes.Add(StatusCodes.ShipType.SUBMARINE);
            this.ShipTypes.Add(StatusCodes.ShipType.CRUISER);
            this.shipTypes.Add(StatusCodes.ShipType.BATTLESHIP);
            this.shipTypes.Add(StatusCodes.ShipType.CARRIER);

            this.gridSize = 10;
            this.playerCanAttackAgain = false;
            this.eachShipGetsAShot = false;
            this.bombCount = 0;
        }

        /// <summary>
        /// Gets or sets the <see cref="fleetSize"/>.
        /// </summary>
        public int FleetSize
        {
            get
            {
                return this.fleetSize;
            }

            set
            {
                if (value == 3 || value == 5 || value == 7)
                {
                    this.fleetSize = value;
                }
                else
                {
                    Logger.ConsoleInformation("Error: the FleetSize can only take in a 3, 5, or 7!");
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="shipTypes"/>.
        /// </summary>
        public List<StatusCodes.ShipType> ShipTypes
        {
            get { return this.shipTypes; }
            set { this.shipTypes = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="gridSize"/>.
        /// </summary>
        public short GridSize
        {
            get
            {
                return this.gridSize;
            }

            set
            {
                if (value == 8 || value == 10 || value == 12)
                {
                    this.gridSize = value;
                }
                else
                {
                    Logger.ConsoleInformation("Error: the GridSize can only take in a 3, 5, or 7!");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the player can attack again after a successful attack.
        /// </summary>
        public bool PlayerCanAttackAgain
        {
            get { return this.playerCanAttackAgain; }
            set { this.playerCanAttackAgain = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the player can attack multiple times based on the number of ships the player has remaining.
        /// </summary>
        public bool EachShipGetsAShot
        {
            get { return this.eachShipGetsAShot; }
            set { this.eachShipGetsAShot = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="bombCount"/>.
        /// </summary>
        public int BombCount
        {
            get { return this.bombCount; }
            set { this.bombCount = value; }
        }
    }
}
