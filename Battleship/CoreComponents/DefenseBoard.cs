//-----------------------------------------------------------------------
// <copyright file="DefenseBoard.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship.CoreComponents
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
        public Ship DestroyerShip;

        /// <summary>
        /// The submarine ship.
        /// </summary>
        public Ship SubmarineShip;

        /// <summary>
        /// The cruiser ship.
        /// </summary>
        public Ship CruiserShip;

        /// <summary>
        /// The battleship.
        /// </summary>
        public Ship BattleshipShip;

        /// <summary>
        /// The carrier ship.
        /// </summary>
        public Ship CarrierShip;

        /// <summary>
        ///  Initializes a new instance of the <see cref="DefenseBoard" /> class.
        /// </summary>
        public DefenseBoard()
        {
            this.DestroyerShip = new Ship();
            this.SubmarineShip = new Ship();
            this.CruiserShip = new Ship();
            this.BattleshipShip = new Ship();
            this.CarrierShip = new Ship();
        }
    }
}
