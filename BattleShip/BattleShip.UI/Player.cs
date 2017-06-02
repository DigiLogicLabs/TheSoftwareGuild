using System;
using System.Runtime.InteropServices;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Player
    {
        public string Name { get; set; }

        public Board DisplayBoard { get; set; }

        //Player board, Name + Display board, attach an active board to compare shots 

        public Player(string name)
        {
            Name = name;

            DisplayBoard = new Board();
        }

        //Victory bool, call true if all ships are sunk

        public bool VictoriousOrNah = false;





        //Extra for checking the position of what user enters, reading the string, and a temporary coordinate spot to compare coordinates to board

//        public string readUserString;
//        private bool validCorrdinate = true;
//        private bool positCheck = true;
//        private string temporaryCoord = null;


        //Placing the ship with positioncheck

        public void PlacingTheShips(Player player)
        {
            for (ShipType sType = ShipType.Destroyer; sType <= ShipType.Carrier; sType++)
            {
                PlaceShip(player, sType);
 
                
            }
        }

        private void PlaceShip(Player p, ShipType sType)
        {
           
            bool successfulPlacement = false;
            while (successfulPlacement == false)
            {
                PlaceShipRequest request = new PlaceShipRequest();
                request.ShipType = sType;
                request.Coordinate = ConsoleInput.GrabCoordinate(p.Name);
                request.Direction = ConsoleInput.GrabDirection(p.Name, sType);

                var response = p.DisplayBoard.PlaceShip(request);

                if (response == ShipPlacement.NotEnoughSpace)
                {
                    ConsoleOutput.ErrorNoSpace();
                }
                else if (response == ShipPlacement.Ok)
                {
                    successfulPlacement = true;
                }
                else
                {
                    ConsoleOutput.ErrorOverLap();
                }

            }
        }


        public void ActivePlayerBoard()
            
            //Board that's compared to the temporary shot holder
        {
            string[,] playersBoardActually = new string[11, 11];

            playersBoardActually[0, 0] = " ";
            playersBoardActually[0, 1] = "1";
            playersBoardActually[0, 2] = "2";
            playersBoardActually[0, 3] = "3";
            playersBoardActually[0, 4] = "4";
            playersBoardActually[0, 5] = "5";
            playersBoardActually[0, 6] = "6";
            playersBoardActually[0, 7] = "7";
            playersBoardActually[0, 8] = "8";
            playersBoardActually[0, 9] = "9";
            playersBoardActually[0, 10] = "10";

            playersBoardActually[1, 0] = "A";
            playersBoardActually[2, 0] = "B";
            playersBoardActually[3, 0] = "C";
            playersBoardActually[4, 0] = "D";
            playersBoardActually[5, 0] = "E";
            playersBoardActually[6, 0] = "F";
            playersBoardActually[7, 0] = "G";
            playersBoardActually[8, 0] = "H";
            playersBoardActually[9, 0] = "I";
            playersBoardActually[10, 0] = "J";

            for (int i = 1; i < playersBoardActually.GetLength(0); i++)
            {
                for (int j = 1; j < playersBoardActually.GetLength(1); j++)
                {
                    playersBoardActually[i, j] = "0";
                }
            }
        }



        


        //extra types for coordinates, shots, and check
//        public bool check = true;
//        public bool coordinateWorks = true;
//        public string temporaryShot = null;



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