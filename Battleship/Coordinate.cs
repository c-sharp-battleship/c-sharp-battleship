using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Coordinate
    {
        protected short XCoordinate;
        protected short YCoordinate;

        public Coordinate()
        {
            XCoordinate = 0;
            YCoordinate = 0;
        }

        public Coordinate(short xCoordinate, short yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}
