using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.UI;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;


namespace BattleShip.UI
{
    class Program
    {
        private static void Main(string[] args)
        {
          GameWorkflow game = new GameWorkflow();

            game.Run();





        }
    }
}
