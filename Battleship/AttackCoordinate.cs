using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class AttackCoordinate : Coordinate
    {
        private AttackStatus CoordinateStatus;

        public AttackStatus GetAttackStatus()
        {
            return CoordinateStatus;
        }

        public AttackCoordinate() : base()
        {
            CoordinateStatus = AttackStatus.NOT_ATTACKED;
        }

        public AttackCoordinate(AttackStatus attackStatus) : base()
        {
            CoordinateStatus = AttackStatus.NOT_ATTACKED;
        }

        public AttackCoordinate(AttackStatus attackStatus, short xCoordinate, short yCoordinate) : base(xCoordinate, yCoordinate)
        {
            CoordinateStatus = AttackStatus.NOT_ATTACKED;
        }
    }
}
