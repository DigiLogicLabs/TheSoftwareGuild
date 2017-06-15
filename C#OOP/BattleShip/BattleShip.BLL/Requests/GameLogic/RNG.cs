using System;

namespace BattleShip.BLL.GameLogic
{
    public static class RNG
    {
        private static Random _generator = new Random();

        public static bool FlipCoin()
        {
            return (_generator.NextDouble() >= .5);
        }
    }
}