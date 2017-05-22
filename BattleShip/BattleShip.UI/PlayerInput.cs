using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Players;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class PlayerInput
    {
        internal static string GetName()
        {
            

            string firstPlayer = Console.ReadLine();
          
            string secondPlayer = Console.ReadLine();

            return firstPlayer + secondPlayer;


           







        }
    }
}
