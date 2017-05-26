using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            SetupWorkflow start = new SetupWorkflow();

            ShipCreator playerShip = new ShipCreator();
        }
    }
}