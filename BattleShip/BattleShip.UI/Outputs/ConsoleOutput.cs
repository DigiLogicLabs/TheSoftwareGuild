using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public static class ConsoleOutput

    {
        public static void SplashScreen()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("            Welcome to Battle Ship!               ");

            Console.WriteLine("_____________¶¶¶¶¶¶¶¶¶¶¶¶¶                        ");
            Console.WriteLine("_____________¶¶___________¶¶                      ");
            Console.WriteLine("______________¶____________¶                      ");
            Console.WriteLine("______________¶_____________¶                     ");
            Console.WriteLine("_______________¶____________¶                     ");
            Console.WriteLine("_______________¶____________¶_¶¶                  ");
            Console.WriteLine("_______________¶__¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶                 ");
            Console.WriteLine("_____¶¶¶¶¶¶¶¶¶¶¶¶¶¶______________¶                ");
            Console.WriteLine("_____¶____________¶¶_____________¶¶____¶          ");
            Console.WriteLine("_____¶¶____________¶_____¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶         ");
            Console.WriteLine("______¶______¶¶¶¶¶¶¶¶¶¶¶¶¶¶______________¶        ");
            Console.WriteLine("______¶¶_____¶¶___________¶______________¶¶       ");
            Console.WriteLine("_______¶______¶____________¶______________¶       ");
            Console.WriteLine("_______¶______¶¶___________¶_____________¶¶       ");
            Console.WriteLine("_______¶_______¶___________¶_____________¶¶       ");
            Console.WriteLine("______¶¶_______¶___________¶¶____________¶        ");
            Console.WriteLine("______¶¶¶¶¶¶¶¶¶¶¶__________¶¶___________¶¶        ");
            Console.WriteLine("___________¶_¶_¶¶________¶¶¶_____¶¶¶¶¶¶¶¶_____¶¶¶ ");
            Console.WriteLine("___________¶_¶_¶¶¶¶¶¶¶¶¶¶¶_¶¶¶¶¶¶¶_______¶¶¶¶¶__¶¶");
            Console.WriteLine("¶¶¶¶¶¶_____¶_¶______¶¶_¶_______¶_¶¶¶¶¶¶¶¶¶___¶¶¶¶¶");
            Console.WriteLine("¶¶___¶¶¶¶¶¶¶¶¶______¶¶_¶____¶¶¶¶¶¶¶________¶¶     ");
            Console.WriteLine("__¶¶________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶____¶¶______¶       ");
            Console.WriteLine("____¶____________________________¶¶_¶____¶        ");
            Console.WriteLine("_____¶_____¶¶¶_____¶¶_____¶¶¶_____¶¶¶___¶¶        ");
            Console.WriteLine("______¶___¶¶_¶¶___¶¶_¶____¶_¶¶__________¶         ");
            Console.WriteLine("_______¶¶_____________________________¶¶          ");
            Console.WriteLine("________¶¶___________________________¶¶           ");
            Console.WriteLine("_________¶¶________________________¶¶¶            ");
            Console.WriteLine("___________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶              ");

            Console.WriteLine("             Press Enter to Start.                ");
            Console.ResetColor();
            Console.ReadLine();
        }

        //Board drawn -- needs physical border
        public static void DrawingBoard(Board displayBoard)
        {
            for (int k = 1; k < 11; k++)
            {
               
                for (int j = 1; j < 11; j++)
                {
                    var gameStatus = displayBoard.CheckCoordinate(new Coordinate(k, j));
                    switch (gameStatus)
                    {
                            case ShotHistory.Unknown:
                                Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(" . ");
                            
                            Console.ResetColor();
                            break;

                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" H ");
                                
                            Console.ResetColor();
                            break;

                                case ShotHistory.Miss:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" M ");
                            
                            Console.ResetColor();
                                    break;
                        
                    }

                }
                Console.WriteLine();
                
            }
        }

        public static void ErrorNoSpaceOrOverlap(ShipPlacement responses)
        {
            if (responses == ShipPlacement.NotEnoughSpace)
            {
                Console.WriteLine("There's not enough space Dude!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.ResetColor();

            }
            else if (responses == ShipPlacement.Overlap)
            {
                Console.WriteLine("You can't place a ship on top of another.. Or at least it's not the best idea. Overlap!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.ResetColor();
            }
                                      
        }

    }
}
