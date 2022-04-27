//-----------------------------------------------------------------------
// <copyright file="ComputerPlayer.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Interaction logic for ComputerPlayer
    /// </summary>
    public class ComputerPlayer : Player
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="ComputerPlayer" /> class.
        /// </summary>
        /// <param name="player_ID"> This is the ID of the player </param>
        /// <param name="player_Name"> this is the name of the Player</param>
        /// <param name="gridcellSize"> This is the size in pixels for the grid square dimension</param>
        /// <param name="maxCol"> This is the max number of columns requested at the moment pf loading</param>
        /// <param name="buttoncolorForDeffense"> this is the color for the button created, refer to Custom button class(switch case in constructor)</param>
        /// <param name="buttoncolorForOffense"> This is the side of the screen to load the canvas, if left then reversed count, if right then incremental from one</param>
        public ComputerPlayer(int player_ID, string player_Name, double gridcellSize, int maxCol, int buttoncolorForDeffense, int buttoncolorForOffense) : base(player_ID, player_Name, gridcellSize, maxCol, buttoncolorForDeffense, buttoncolorForOffense)
        {
        }
    }
}
