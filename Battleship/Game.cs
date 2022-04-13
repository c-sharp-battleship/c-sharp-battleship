using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Game
    {
        private string ID;
        private Player Player1;
        private Player Player2;

        public string GetID()
        {
            return ID;
        }

        Game()
        {
            ID = 0.ToString();
            Player1 = new Player();
            Player2 = new Player();
        }
    }
}
