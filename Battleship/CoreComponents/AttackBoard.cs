//-----------------------------------------------------------------------
// <copyright file="AttackBoard.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class which is used to represent an attack board.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class AttackBoard
    {
        /// <summary>
        /// The list of attack coordinates that are hit.
        /// </summary>
        private List<AttackCoordinate> hitCoords;

        /// <summary>
        /// The list of attack coordinates that are missed.
        /// </summary>
        private List<AttackCoordinate> missCoords;

        /// <summary>
        ///  Initializes a new instance of the <see cref="AttackBoard" /> class.
        /// </summary>
        public AttackBoard()
        {
            this.hitCoords = new List<AttackCoordinate>();
            this.missCoords = new List<AttackCoordinate>();
        }
    }
}
