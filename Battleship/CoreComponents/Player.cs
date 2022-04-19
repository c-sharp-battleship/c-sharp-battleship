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
        public string ID;

        /// <summary>
        /// The Username of the player.
        /// </summary>
        public string Username;

        /// <summary>
        /// The attack board that the player attacks.
        /// </summary>
        public AttackBoard PlayerAttackBoard;

        /// <summary>
        /// The defense board that the player defenses.
        /// </summary>
        public DefenseBoard PlayerDefenseBoard;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        public Player()
        {
            this.ID = 0.ToString();
            this.Username = string.Empty;
            this.PlayerAttackBoard = new AttackBoard();
            this.PlayerDefenseBoard = new DefenseBoard();
        }
    }
}
