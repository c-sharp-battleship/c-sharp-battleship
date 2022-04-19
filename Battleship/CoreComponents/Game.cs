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
        public StatusCodes.ApplicationStatus GameStatus;

        /// <summary>
        /// The ID of the game.
        /// </summary>
        private string ID;

        /// <summary>
        /// The player #1.
        /// </summary>
        private Player Player1;

        /// <summary>
        /// The player #2.
        /// </summary>
        private Player Player2;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Game" /> class.
        /// </summary>
        public Game()
        {
            this.ID = 0.ToString();
            this.Player1 = new Player();
            this.Player2 = new Player();

            this.GameStatus = StatusCodes.ApplicationStatus.GAME_NOT_STARTED;
            Logger.ConsoleInformation("Game Initialized");
        }

        public void StartGame(string player1Name, string player2Name)
        {
            this.GameStatus = StatusCodes.ApplicationStatus.GAME_STARTED;
            Logger.ConsoleInformation("Game Started");

            this.Player1.Username = player1Name;
            this.Player2.Username = player2Name;
        }
    }
}
