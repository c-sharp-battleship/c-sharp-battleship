using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Ship
    {
        private short Length;
        private Coordinate ShipStartCoords;
        private Coordinate ShipEndCoords;
        private bool IsSunk;

        public Ship()
        {
            Length = 0;

            ShipStartCoords = new Coordinate();
            ShipEndCoords = new Coordinate();

            IsSunk = false;
        }

        public Ship(short length, short[] shipStartCoords, short[] shipEndCoords, bool isSunk)
        {
            Length = length;

            ShipStartCoords = new Coordinate(shipStartCoords[0], shipStartCoords[1]);
            ShipEndCoords = new Coordinate(shipEndCoords[0], shipEndCoords[1]);

            IsSunk = isSunk;
        }
    }
}
