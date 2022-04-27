using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class ComputerPlayer : Player
    {
        public ComputerPlayer(int Player_ID, string Player_Name, double gridcellSize, int maxCol, int buttoncolorForDeffense, int buttoncolorForOffense) : base(Player_ID, Player_Name, gridcellSize, maxCol, buttoncolorForDeffense, buttoncolorForOffense)
        {

        }
    }
}
