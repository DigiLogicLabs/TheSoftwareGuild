using System;

namespace BattleShip.UI
{
    public class PlayerInput
    {
        internal static string GetName()
        {
            string playerNameSet = Console.ReadLine();

            return playerNameSet;
        }
    }
}