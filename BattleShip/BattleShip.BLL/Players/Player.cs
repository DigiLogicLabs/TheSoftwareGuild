using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;

namespace BattleShip.BLL.Players
{
    public class Player
    {
        public string Name { get; set; }

        public Board DisplayBoard { get; set; }

        public Player(string name)
        {
            Name = name;

            DisplayBoard = new Board();
        }

        public bool VictoriousOrNah = false;

        public int Grabx(string s)
        {
            string letterInteger;
            if (s == "")
            {
                {
                    Console.WriteLine($"{Name}, not a valid coordinate, change your X!");
                    Console.Clear();
                }
                letterInteger = s.Substring(0, 1);
                switch (letterInteger)
                {
                    case "A":
                    case "a":
                        x = 1;
                        return x;

                    case "B":
                    case "b":
                        x = 2;
                        return x;

                    case "C":
                    case "c":
                        x = 3;
                        return x;

                    case "D":
                    case "d":
                        x = 4;
                        return x;

                    case "E":
                    case "e":
                        x = 5;
                        return x;

                    case "F":
                    case "f":
                        x = 6;
                        return x;

                    case "G":
                    case "g":
                        x = 7;
                        return x;

                    case "H":
                    case "h":
                        x = 8;
                        return x;

                    case "I":
                    case "i":
                        x = 9;
                        return x;

                    case "J":
                    case "j":
                        x = 10;
                        return x;
                }
            }
            return x;
        }

        public int GetY(string s)
        {
            int y;
            if (s == "")
            {
                Console.WriteLine($"{Name}, not a valid coordinate, change your Y!");
            }
            int.TryParse(s.Substring(1), out y);
            if (y < 1 || y > 10)
            {
                Console.WriteLine($"{Name}, Y coordinate too large or too small!");
            }
            return y;
        }


        public string readUserString;
        private bool validCorrdinate = true;
        private bool positCheck = true;
        private string temporaryCoord = null;

        public void PlaceDaShip(Player player, Board board)
        {
            foreach (var sType in Enum.GetValues(typeof(ShipType)))
            {
                int x = 0;
                int y = 0;
                while (positCheck == true)
                {
                    Console.Clear();
                    DrawingBoard();
                    Console.WriteLine($"{Name}, enter a starting coordinate for your {(ShipType)sType}.");
                    Console.WriteLine("Destroyer = 2 , Submarine = 3, Cruiser = 3, Battleship = 4, Carrier = 5");
                    temporaryCoord = Console.ReadLine();

                    x = player.Grabx(temporaryCoord);
                    y = player.GetY(temporaryCoord);
                    if (y > 10 || y < 1)
                    {
                        validCorrdinate = false;
                    }
                    validCorrdinate = true;

                    var direction = ShipDirection.Up;

                    while (true)
                    {
                        Console.WriteLine($"{Name}, Enter a direction for your {(ShipType)sType}'s placement:");
                        Console.WriteLine("U = up, D = down, R = right, L = left");

                        readUserString = Console.ReadLine();
                        if (readUserString == "U" || readUserString == "u")
                        {
                            direction = ShipDirection.Up;
                            break;
                        }
                        else if (readUserString == "D" || readUserString == "d")
                        {
                            direction = ShipDirection.Down;
                            break;
                        }
                        else if (readUserString == "R" || readUserString == "r")
                        {
                            direction = ShipDirection.Right;
                            break;
                        }
                        else if (readUserString == "L" || readUserString == "l")
                        {
                            direction = ShipDirection.Left;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Not a valid direction, enter a new direction");
                        }

                        PlaceShipRequest p = new PlaceShipRequest();
                        {
                            Coordinate c = new Coordinate(x, y);
                            ShipType s = (ShipType)sType;
                        }

                        var response = board.PlaceShip(p);
                        if (response == ShipPlacement.NotEnoughSpace)
                        {
                            Console.WriteLine($"Not enough space for placement of {(ShipType)sType}, give it another go!");
                            Console.ReadKey();
                        }
                        else if (response == ShipPlacement.Overlap)
                        {
                            Console.WriteLine($"You probably don't want your {(ShipType)sType} on top of another ship...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"{(ShipType)sType} was deployed successfully!");
                            Console.ReadKey();
                            Console.Clear();
                            positCheck = false;
                        }
                    }
                    positCheck = true;
                }
            }
        }

        public void ActivePlayerBoard()
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

        public void DrawingBoard()
        {
            string[,] playersBoardActually = new string[11, 11];
            for (int i = 0; i < playersBoardActually.GetLength(0); i++)
            {
                for (int j = 0; j < playersBoardActually.GetLength(1); j++)
                {
                    if (playersBoardActually[i, j] == "H")
                    {
                    }
                }
            }
        }

        public bool check = true;
        public bool coordinateWorks = true;
        public int x = 0;
        public int y = 0;
        public string temporaryShot = null;

        public void HotShots()

        {
            while (check == true)
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
            }
        }
    }
}