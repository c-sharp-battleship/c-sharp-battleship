using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class AttackCoordinate : Coordinate
    {
        /// <summary>
        /// The status of coordinates that are attacked.
        /// </summary>
        public StatusCodes.AttackStatus CoordinateStatus;

        /// <summary>
        ///  Initializes a new instance of the <see cref="AttackCoordinate" /> class.
        /// </summary>
        public AttackCoordinate() : base()
        {
            this.CoordinateStatus = StatusCodes.AttackStatus.NOT_ATTACKED;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="AttackCoordinate" /> class.
        /// </summary>
        /// <param name="attackStatus">The first name to join.</param>
        public AttackCoordinate(StatusCodes.AttackStatus attackStatus) : base()
        {
            this.CoordinateStatus = StatusCodes.AttackStatus.NOT_ATTACKED;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="AttackCoordinate" /> class.
        /// </summary>
        /// <param name="attackStatus">The attack status.</param>
        /// <param name="xCoordinate">The x coordinate.</param>
        /// <param name="yCoordinate">The y coordinate.</param>
        public AttackCoordinate(StatusCodes.AttackStatus attackStatus, short xCoordinate, short yCoordinate) : base(xCoordinate, yCoordinate)
        {
            this.CoordinateStatus = StatusCodes.AttackStatus.NOT_ATTACKED;
        }

        /// <summary>
        /// Returns the status of coordinates that are attacked
        /// </summary>
        /// <returns>The coordinate status.</returns>
        public StatusCodes.AttackStatus GetAttackStatus()
        {
            return this.CoordinateStatus;
        }
    }
}
