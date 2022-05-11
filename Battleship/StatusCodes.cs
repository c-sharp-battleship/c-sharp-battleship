//-----------------------------------------------------------------------
// <copyright file="StatusCodes.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
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
            ATTACKED_HIT,
        }

        /// <summary>
        /// Types of applications statuses.
        /// </summary>
        public enum ApplicationStatus
        {
            /// <summary>
            /// Represents a game not yet started.
            /// </summary>
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
            GAME_ENDED,
        }

        /// <summary>
        /// Types of game types.
        /// </summary>
        public enum GameType
        {
            /// <summary>
            /// Represents a player to player game.
            /// </summary>
            PLAYER_TO_PLAYER,

            /// <summary>
            /// Represents a player to computer game.
            /// </summary>
            PLAYER_TO_COMPUTER,

            /// <summary>
            /// Represents a computer to computer game.
            /// </summary>
            COMPUTER_TO_COMPUTER,
        }

        /// <summary>
        /// Types of grid space statuses.
        /// </summary>
        public enum GridSpaceStatus
        {
            /// <summary>
            /// Indicates that the grid space is occupied.
            /// </summary>
            GRID_SPACE_OCCUPIED,

            /// <summary>
            /// Indicates that the grid space is not occupied.
            /// </summary>
            GRID_SPACE_NOT_OCCUPIED,
        }

        /// <summary>
        /// Indicates the computer player difficulty.
        /// </summary>
        public enum ComputerPlayerDifficulty
        {
            /// <summary>
            /// Represents an no computer player difficulty.
            /// </summary>
            NO_COMPUTER_DIFFICULTY,

            /// <summary>
            /// Represents an easy computer player difficulty.
            /// </summary>
            COMPUTER_DIFFICULTY_EASY,

            /// <summary>
            /// Represents a hard computer player difficulty.
            /// </summary>
            COMPUTER_DIFFICULTY_HARD,
        }

        /// <summary>
        /// Indicates the computer attack strategy.
        /// </summary>
        public enum AttackStrategy
        {
            /// <summary>
            /// Represents an easy attack strategy.
            /// </summary>
            ATTACK_DIFFICULTY_EASY,

            /// <summary>
            /// Represents a hard attack strategy.
            /// </summary>
            ATTACK_DIFFICULTY_HARD,
        }

        /// <summary>
        /// Indicates the computer defense strategy.
        /// </summary>
        public enum DefenseStrategy
        {
            /// <summary>
            /// Represents an easy defense strategy.
            /// </summary>
            DEFENSE_DIFFICULTY_EASY,

            /// <summary>
            /// Indicates a defense strategy in which ships are placed towards the corners.
            /// </summary>
            DEFENSE_DIFFICULTY_CORNER,

            /// <summary>
            /// Indicates a defense strategy in which ships are placed towards the center.
            /// </summary>
            DEFENSE_DIFFICULTY_CENTER,
        }

        /// <summary>
        /// Represents the ship type.
        /// </summary>
        public enum ShipType
        {
            /// <summary>
            /// Represents a destroyer ship.
            /// </summary>
            DESTROYER,

            /// <summary>
            /// Represents a submarine ship.
            /// </summary>
            SUBMARINE,

            /// <summary>
            /// Represents a cruiser ship.
            /// </summary>
            CRUISER,

            /// <summary>
            /// Represents a battleship ship.
            /// </summary>
            BATTLESHIP,

            /// <summary>
            /// Represents a carrier ship.
            /// </summary>
            CARRIER,
        }

        /// <summary>
        /// Represents the player type.
        /// </summary>
        public enum PlayerType
        {
            /// <summary>
            /// Represents a human player.
            /// </summary>
            PLAYER,

            /// <summary>
            /// Represents a computer player.
            /// </summary>
            COMPUTER,

            /// <summary>
            /// Represents a player other than human or computer (invalid player type).
            /// </summary>
            OTHER,
        }
    }
}