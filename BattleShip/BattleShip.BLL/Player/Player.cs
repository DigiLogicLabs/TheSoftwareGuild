using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.BLL.Player
{
    public class Player
    {
        public string Name { get; set; }
        public Board PBoard { get; set; }

        public Player(string name)
        {
            Name = name;
            PBoard = new Board();
        }
    }
}
