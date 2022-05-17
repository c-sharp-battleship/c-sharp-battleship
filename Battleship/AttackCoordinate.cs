//-----------------------------------------------------------------------
// <copyright file="AttackCoordinate.cs" company="David Fedchuk, Gerson Eliu Sorto Flores, Lincoln Kaszynski, Sanaaia Okhlopkova, and Samuel Mace">
//     MIT License, 2022 (https://mit-license.org).
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    /// <summary>
    /// Interaction logic for AttackCoordinate.
    /// </summary>
    public class AttackCoordinate : Coordinate
    {
        /// <summary>
        /// The status of coordinates that are attacked.
        /// </summary>
        private StatusCodes.AttackStatus coordinateStatus;

        /// <summary>
        ///  Initializes a new instance of the <see cref="AttackCoordinate" /> class.
        /// </summary>
        public AttackCoordinate()
        {
            this.coordinateStatus = StatusCodes.AttackStatus.NOT_ATTACKED;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="AttackCoordinate" /> class.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate.</param>
        /// <param name="yCoordinate">The y coordinate.</param>
        public AttackCoordinate(short xCoordinate, short yCoordinate)
            : base(xCoordinate, yCoordinate)
        {
            this.coordinateStatus = StatusCodes.AttackStatus.NOT_ATTACKED;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="AttackCoordinate" /> class.
        /// </summary>
        /// <param name="attackStatus">The first name to join.</param>
        public AttackCoordinate(StatusCodes.AttackStatus attackStatus)
        {
            this.coordinateStatus = StatusCodes.AttackStatus.NOT_ATTACKED;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="AttackCoordinate" /> class.
        /// </summary>
        /// <param name="attackStatus">The attack status.</param>
        /// <param name="xCoordinate">The x coordinate.</param>
        /// <param name="yCoordinate">The y coordinate.</param>
        public AttackCoordinate(StatusCodes.AttackStatus attackStatus, short xCoordinate, short yCoordinate)
            : base(xCoordinate, yCoordinate)
        {
            this.CoordinateStatus = StatusCodes.AttackStatus.NOT_ATTACKED;
        }

        /// <summary>
        /// Gets or sets the status of coordinates that are attacked.
        /// </summary>
        /// <returns>The coordinate status.</returns>
        public StatusCodes.AttackStatus CoordinateStatus
        {
            get { return this.coordinateStatus; }
            set { this.coordinateStatus = value; }
        }

        /// <summary>
        /// Returns the status of coordinates that are attacked.
        /// </summary>
        /// <returns>The coordinate status.</returns>
        public StatusCodes.AttackStatus GetAttackStatus()
        {
            return this.coordinateStatus;
        }
    }
}
