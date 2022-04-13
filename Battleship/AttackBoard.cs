using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class AttackBoard
    {
        private List<AttackCoordinate> HitCoords;
        private List<AttackCoordinate> MissCoords;

        public AttackBoard()
        {
            this.HitCoords = new List<AttackCoordinate>();
            this.MissCoords = new List<AttackCoordinate>();
        }
    }
}
