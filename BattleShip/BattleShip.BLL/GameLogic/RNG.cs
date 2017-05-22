using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.GameLogic
{
    public static class RNG
    {
        static Random _generator = new Random();

        public static bool FlipCoin()
        {
            return (_generator.NextDouble() >= .5);
           
        }

    }
}
