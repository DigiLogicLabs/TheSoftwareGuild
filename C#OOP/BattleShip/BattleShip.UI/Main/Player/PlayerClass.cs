using System;
using System.Runtime.InteropServices;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    //The whole PlayerClass has been moved to a Player folder in BLL. So many reworks.
    public class PlayerClass
    {
        public bool VictoriousOrNah = false;

        public string Name { get; set; }
        public Board DisplayBoard { get; set; }

        //PlayerClass board, Name + Display board, attach an active board to compare shots 

       

        //Placing the ship with positioncheck

//        public void PlaceShip(PlayerClass p, PlayersNameset n)
//        {
//           
//            bool successfulPlacement = false;
//            for (ShipType sType = ShipType.Destroyer; sType <= ShipType.Carrier; sType++)
//            {
//                while (successfulPlacement == false)
//                {
//                    PlaceShipRequest request = new PlaceShipRequest();
//                    request.ShipType = sType;
//                    request.Coordinate = ConsoleInput.GrabCoordinate(n.Name);
//                    request.Direction = ConsoleInput.GrabDirection(n.Name, sType);
//
//                    var response = p.DisplayBoard.PlaceShip(request);
//
//                    if (response == ShipPlacement.NotEnoughSpace)
//                    {
//                        ConsoleOutput.ErrorNoSpace();
//                    }
//                    else if (response == ShipPlacement.Ok)
//                    {
//                        successfulPlacement = true;
//                    }
//                    else
//                    {
//                        ConsoleOutput.ErrorOverLap();
//                    }
//
//                }
//
//
//            }
//            
//        }


        public void ActivePlayerBoard()
            
            //Board that's compared to the temporary shot holder
        {
            string[,] playersBoard = new string[11, 11];

            playersBoard[0, 0] = " ";
            playersBoard[0, 1] = "1";
            playersBoard[0, 2] = "2";
            playersBoard[0, 3] = "3";
            playersBoard[0, 4] = "4";
            playersBoard[0, 5] = "5";
            playersBoard[0, 6] = "6";
            playersBoard[0, 7] = "7";
            playersBoard[0, 8] = "8";
            playersBoard[0, 9] = "9";
            playersBoard[0, 10] = "10";

            playersBoard[1, 0] = "A";
            playersBoard[2, 0] = "B";
            playersBoard[3, 0] = "C";
            playersBoard[4, 0] = "D";
            playersBoard[5, 0] = "E";
            playersBoard[6, 0] = "F";
            playersBoard[7, 0] = "G";
            playersBoard[8, 0] = "H";
            playersBoard[9, 0] = "I";
            playersBoard[10, 0] = "J";

            for (int i = 1; i < playersBoard.GetLength(0); i++)
            {
                for (int j = 1; j < playersBoard.GetLength(1); j++)
                {
                    playersBoard[i, j] = "0";
                }
            }
        }

        //Shot status comparison
        public void ShotsFromPlayers(int x, int y)

        {
           throw new NotImplementedException();
          /*  while (check == true)
            {
                while (coordinateWorks == true)
                {
                    Console.Clear();
                    DrawingBoard();

                    Console.WriteLine($"{Name}, enter a coordinate Masta!");

                    temporaryShot = Console.ReadLine();
                }
            }
            Console.WriteLine($"{Name}, fire when ready Masta!");
            temporaryShot = Console.ReadLine();

            var coordinates = new Coordinate(x, y);
            var respo = new FireShotResponse();

            if (respo.ShotStatus == ShotStatus.Duplicate)
            {
                Console.WriteLine($"{Name}, you recently fired there!!");
                Console.ReadLine();
            }
            else if (respo.ShotStatus == ShotStatus.HitAndSunk)
            {
                Console.WriteLine($"{Name}, Awesome shot rookie!");
            }
            else if (respo.ShotStatus == ShotStatus.Hit)
            {
                Console.WriteLine($"{Name}, Right on Target!!");
            }
            else if (respo.ShotStatus == ShotStatus.Invalid)
            {
                Console.WriteLine($"{Name}, Let's shoot somewhere that matters..");
            }
            else if (respo.ShotStatus == ShotStatus.Miss)
            {
                Console.WriteLine($"{Name}, Are you trying to waste ammo??");
            }
            else if (respo.ShotStatus == ShotStatus.Victory)
            {
                Console.WriteLine($"{Name}, the enemy has been Defeated!");
            }*/
        }
    }
}