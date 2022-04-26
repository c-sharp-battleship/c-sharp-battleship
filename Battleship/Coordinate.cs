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

        public char XCoordinateLetter
        {
            get
            {
                switch (this.XCoordinate)
                {
                    case 1:
                        return 'A';
                        break;
                    case 2:
                        return 'B';
                        break;
                    case 3:
                        return 'C';
                        break;
                    case 4:
                        return 'D';
                        break;
                    case 5:
                        return 'E';
                        break;
                    case 6:
                        return 'F';
                        break;
                    case 7:
                        return 'G';
                        break;
                    case 8:
                        return 'H';
                        break;
                    case 9:
                        return 'I';
                        break;
                    case 10:
                        return 'J';
                        break;
                    default:
                        return 'Z';
                        break;
                }
            }
        }

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
