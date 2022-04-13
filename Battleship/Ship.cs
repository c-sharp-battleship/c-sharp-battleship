//-----------------------------------------------------------------------
// <copyright file="Ship.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class which is used to represent a ship.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Ship
    {
        /// <summary>
        /// The length of the ship.
        /// </summary>
        private short length;

        /// <summary>
        /// The starting coordinates of the ship.
        /// </summary>
        private Coordinate shipStartCoords;

        /// <summary>
        /// The ending coordinates of the ship.
        /// </summary>
        private Coordinate shipEndCoords;

        /// <summary>
        /// Is ship is sunk or not.
        /// </summary>
        private bool isSunk;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Ship" /> class.
        /// </summary>
        public Ship()
        {
            this.length = 0;

            this.shipStartCoords = new Coordinate();
            this.shipEndCoords = new Coordinate();

            this.isSunk = false;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Ship" /> class.
        /// </summary>
        /// <param name="length">The length of the ship.</param>
        /// <param name="shipStartCoords">The starting coordinates of the ship.</param>
        /// <param name="shipEndCoords">The ending coordinates of the ship.</param>
        /// <param name="isSunk">Is ship is sunk or not.</param>
        public Ship(short length, short[] shipStartCoords, short[] shipEndCoords, bool isSunk)
        {
            this.length = length;

            this.shipStartCoords = new Coordinate(shipStartCoords[0], shipStartCoords[1]);
            this.shipEndCoords = new Coordinate(shipEndCoords[0], shipEndCoords[1]);

            this.isSunk = isSunk;
        }
    }
}
