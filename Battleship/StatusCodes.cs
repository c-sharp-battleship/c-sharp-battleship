//-----------------------------------------------------------------------
// <copyright file="StatusCodes.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    /// <summary>
    /// Implementation of project-wide status codes.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class StatusCodes
    {
        /// <summary>
        /// Types of attack statuses.
        /// </summary>
        public enum AttackStatus
        {
            /// <summary>
            /// Represents a not attacked status.
            /// </summary>
            NOT_ATTACKED,

            /// <summary>
            /// Represents an attacked but not hit status.
            /// </summary>
            ATTACKED_NOT_HIT,

            /// <summary>
            /// Represents an attacked and hit status.
            /// </summary>
            ATTACKED_HIT
        }

        /// <summary>
        /// Types of applications statuses.
        /// </summary>
        public enum ApplicationStatus
        {
            GAME_NOT_STARTED,
            /// <summary>
            /// Represents a start of a game.
            /// </summary>
            GAME_STARTED,

            /// <summary>
            /// Represents a player1.
            /// </summary>
            PLAYER_1_TURN,

            /// <summary>
            /// Represents a player2.
            /// </summary>
            PLAYER_2_TURN,

            /// <summary>
            /// Represents an end of the game.
            /// </summary>
            GAME_ENDED
        }
    }
}