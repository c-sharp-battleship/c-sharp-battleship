using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Player
    {
        private string ID;
        private string Username;
        private AttackBoard PlayerAttackBoard;
        private DefenseBoard PlayerDefenseBoard;

        public Player()
        {
            ID = 0.ToString();
            Username = "";
            PlayerAttackBoard = new AttackBoard();
            PlayerDefenseBoard = new DefenseBoard();
        }
    }
}
