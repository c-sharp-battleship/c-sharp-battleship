//-----------------------------------------------------------------------
// <copyright file="DefenseBoard.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class which is used to represent a defense board.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class DefenseBoard
    {
        /// <summary>
        /// The destroyer ship.
        /// </summary>
        private Ship destroyerShip;

        /// <summary>
        /// The submarine ship.
        /// </summary>
        private Ship submarineShip;

        /// <summary>
        /// The cruiser ship.
        /// </summary>
        private Ship cruiserShip;

        /// <summary>
        /// The battleship.
        /// </summary>
        private Ship battleshipShip;

        /// <summary>
        /// The carrier ship.
        /// </summary>
        private Ship carrierShip;

        /// <summary>
        ///  Initializes a new instance of the <see cref="DefenseBoard" /> class.
        /// </summary>
        public DefenseBoard()
        {
            this.destroyerShip = new Ship();
            this.submarineShip = new Ship();
            this.cruiserShip = new Ship();
            this.battleshipShip = new Ship();
            this.carrierShip = new Ship();
        }
    }
}
