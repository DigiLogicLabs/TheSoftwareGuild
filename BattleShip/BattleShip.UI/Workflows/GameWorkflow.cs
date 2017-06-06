using System;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class GameWorkflow
    {
        private SetupWorkflow _setupWorkflow = new SetupWorkflow();

        public string Name { get; set; }

        public void Run()
        {
            bool playAgain = true;
            ConsoleOutput.SplashScreen(); // Printed start screen


            _setupWorkflow.BeginningGameInfo();

            var pTurns = _setupWorkflow.P1Turn;


            while (playAgain)
            {
                var gameShotStatus = new ShotStatus();

                Console.Clear();

                if (pTurns)
                {
                    gameShotStatus = FireShotPrompt(_setupWorkflow.P2.PBoard, _setupWorkflow.P1.Name);
                    pTurns = !pTurns;
                }

                else
                {
                    pTurns = !pTurns;

                    gameShotStatus = FireShotPrompt(_setupWorkflow.P1.PBoard, _setupWorkflow.P2.Name);
                    
                    
                }
                pTurns = !pTurns;

                if (gameShotStatus == ShotStatus.Invalid || gameShotStatus == ShotStatus.Duplicate)
                {
                    pTurns = !pTurns;
                }
                pTurns = !pTurns;

                if (gameShotStatus != ShotStatus.Victory)
                {
                    playAgain = true;
                    
                }
                else
                {
                    playAgain = false;
                    

                    Console.WriteLine("Q to quit or Enter to play again.");

                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        SetupWorkflow rePlay = new SetupWorkflow();
                        rePlay.BeginningGameInfo();
                    }
                    if (Console.ReadKey().Key == ConsoleKey.Q)
                    {
                        return;
                    }

                }
                

            }



        }

        private ShotStatus FireShotPrompt(Board shootingBoard, string pName)
        {
            
            ConsoleOutput.DrawingBoard(shootingBoard);

            Console.WriteLine($"{pName}, select your shot location on the enemies ship.");
            Coordinate shootingCoordinate = ConsoleInput.GrabCoordinate();

            var shot = shootingBoard.FireShot(shootingCoordinate);
            if (shot.ShotStatus == ShotStatus.Invalid)
            {
                Console.WriteLine("Invalid shot, please try again!");

            }
            else if (shot.ShotStatus == ShotStatus.Duplicate)
            {
                Console.WriteLine("You've already shot there! Try again");
            }
            else if (shot.ShotStatus == ShotStatus.Miss)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Shot missed! Next players turn.");
                Console.ResetColor();
                Console.ReadLine();

            }
            else if (shot.ShotStatus == ShotStatus.Hit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Shot Hit! Next players turn.");
                Console.ResetColor();
                Console.ReadLine();

            }
            else if (shot.ShotStatus == ShotStatus.HitAndSunk)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Shot Hit and sunk the ship! Next players turn.");
                Console.ResetColor();
                Console.ReadLine();

            }
            else if (shot.ShotStatus == ShotStatus.Victory)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"                         {pName} Is Victorious!                              ");
                Console.ResetColor();
                Console.ReadKey();

            }

           
            return shot.ShotStatus;
        }

       
    }

   
}
