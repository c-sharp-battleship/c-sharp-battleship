//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship.CoreComponents
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class which is used to represent a player.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Player
    {
        /// <summary>
        /// The ID of the player.
        /// </summary>
        private string id;

        /// <summary>
        /// The Username of the player.
        /// </summary>
        private string username;

        /// <summary>
        /// The attack board that the player attacks.
        /// </summary>
        private AttackBoard playerAttackBoard;

        /// <summary>
        /// The defense board that the player defenses.
        /// </summary>
        private DefenseBoard playerDefenseBoard;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        public Player()
        {
            this.id = 0.ToString();
            this.username = string.Empty;
            this.playerAttackBoard = new AttackBoard();
            this.playerDefenseBoard = new DefenseBoard();
        }
    }
}
