using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
   public static class ConsoleInput
    {
        public static void PlayerNameSet()
        {
            Console.WriteLine("Player 1 Enter your name: ");
           string p1Name = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Player 2 Enter your name: ");
            string p2Name = Console.ReadLine();

            

        }

        public static Coordinate GrabCoordinate(string name)
        {
            bool positCheck = true;
            int x = 0;
            int y = 0;
            while (positCheck)
            {
                Console.Clear();
                ConsoleOutput.DrawingBoard();
                Console.WriteLine($"{name}, please enter a coordinate.");
                
                string temporaryCoord = Console.ReadLine();

                x = GrabX(temporaryCoord, name);

                //TODO: check value of x...if it's -1 input was invalid
                y = GetY(temporaryCoord, name);
                if (y > 10 || y < 1)
                {

                }
            }
            throw new NotImplementedException();
        }


        public static ShipDirection GrabDirection(string name, ShipType sType)
        {
            while (true)
            {
                var direction = ShipDirection.Down;

                Console.WriteLine($"{name}, Enter a direction for your {sType}'s placement:");
                Console.WriteLine("U = up, D = down, R = right, L = left");

                string readUserString = Console.ReadLine();
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

            }
            throw new NotImplementedException();
        }
       
        
        
        //Take the X coordinate from the user
        public static int GrabX(string s, string name)
        {
            int x = -1;

            string letterInteger;
            if (s == "")
            {

                Console.WriteLine($"{name}, not a valid coordinate, change your X!");
            }
            else
            {

                //Switch statement to outline what each letter (A-J (Capitalized or not)) will equate to for position on board
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



        //Take the Y coordinate from the user
        public static int GetY(string s, string name)
        {
            //Second coordinate after A-J, 1-10. If greater than 10 or less than 1, give new coordinates.
            int y;
            if (s == "")
            {
                
                Console.WriteLine($"{name}, not a valid coordinate, change your Y!");
            }
            int.TryParse(s.Substring(1), out y);
            if (y < 1 || y > 10)
            {
                Console.WriteLine($"{name}, Y coordinate too large or too small!");
            }
            return y;
        }
    }
}
