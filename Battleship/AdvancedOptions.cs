//-----------------------------------------------------------------------
// <copyright file="AdvancedOptions.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System.Collections.Generic;

    public class AdvancedOptions
    {
        // Rule 1 - Adjustable Fleet Sizes

        /// <summary>
        /// Specifies how many ships each player's fleet should contain.
        /// </summary>
        private int fleetSize;

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

        private List<StatusCodes.ShipType> shipTypes;

        public List<StatusCodes.ShipType> ShipTypes
        {
            get { return shipTypes; }
            set { this.shipTypes = value; }
        }

        // Rule 2 - Adjustable Grid Size

        /// <summary>
        /// Specifies the length and width of each board.
        /// </summary>
        private short gridSize;

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

        // Rule 3 - If a Player Gets Hit, They Can Attack Again

        /// <summary>
        /// Determines whether or not the player can attack multiple times follow.
        /// </summary>
        private bool playerCanAttackAgain;

        public bool PlayerCanAttackAgain
        {
            get { return this.playerCanAttackAgain; }
            set { this.playerCanAttackAgain = value; }
        }

        // Rule 4 - Each Ship Gets a Shot

        private bool eachShipGetsAShot;

        public bool EachShipGetsAShot
        {
            get { return this.eachShipGetsAShot; }
            set { this.eachShipGetsAShot = value; }
        }

        // Rule 5 - Player Gets a "Bomb" Move

        private bool playerGetsABombMove;

        public bool PlayerGetsABombMove
        {
            get { return this.eachShipGetsAShot; }
            set { this.eachShipGetsAShot = value; }
        }
    }
}
