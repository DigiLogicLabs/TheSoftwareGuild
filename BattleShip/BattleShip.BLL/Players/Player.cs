using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Players;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.BLL.Players
{
    public class Player
    {
      

        public string Name { get; set; }

        public Board DisplayBoard { get; set; }

        public Player (string name)
        {
            Name = name;

            DisplayBoard = new Board();
            
        }
        
        
        





    }
}
