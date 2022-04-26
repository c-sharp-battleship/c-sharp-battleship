using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Coordinate
    {
        /// <summary>
        /// The y position of the coordinate.
        /// </summary>
        public short XCoordinate;

        /// <summary>
        /// The y position of the coordinate.
        /// </summary>
        public short YCoordinate;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Coordinate" /> class.
        /// </summary>
        public Coordinate()
        {
            this.XCoordinate = 0;
            this.YCoordinate = 0;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Coordinate" /> class.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate</param>
        /// <param name="yCoordinate">The y coordinate.</param>
        public Coordinate(short xCoordinate, short yCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }
    }
}
