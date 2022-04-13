using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class DefenseBoard
    {
        private Ship DestroyerShip;
        private Ship SubmarineShip;
        private Ship CruiserShip;
        private Ship BattleshipShip;
        private Ship CarrierShip;

        public DefenseBoard()
        {
            DestroyerShip = new Ship();
            SubmarineShip = new Ship();
            CruiserShip = new Ship();
            BattleshipShip = new Ship();
            CarrierShip = new Ship();
        }
    }
}
