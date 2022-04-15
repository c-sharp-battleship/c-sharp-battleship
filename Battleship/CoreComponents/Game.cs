//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship.CoreComponents
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class which is used to represent a game.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Game
    {
        /// <summary>
        /// The ID of the game.
        /// </summary>
        private string id;

        /// <summary>
        /// The player #1.
        /// </summary>
        private Player player1;

        /// <summary>
        /// The player #2.
        /// </summary>
        private Player player2;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Game" /> class.
        /// </summary>
        public Game()
        {
            this.id = 0.ToString();
            this.player1 = new Player();
            this.player2 = new Player();
        }

        /// <summary>
        ///  Returns the id of the game.
        /// </summary>
        /// <returns>The id of the game.</returns>
        public string GetID()
        {
            return this.id;
        }
    }
}
