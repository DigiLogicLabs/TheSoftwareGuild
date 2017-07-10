using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI;

namespace BattleShip.UI
{
   public static class ConsoleInput
    {

        public static Coordinate GrabCoordinate()
        {
            bool invalidInput = true;
            int x = 0;
            int y = 0;


            string temporaryCoord = "";
            

            while (invalidInput)
            {
                
                temporaryCoord = Console.ReadLine();

                Console.Clear();

               

                x = GrabX(temporaryCoord);

                
                y = GetY(temporaryCoord);

               
                if (y > 10 || y < 1 || x< 1 || x> 10)
                {
                    Console.WriteLine($"You've entered an invalid coordinate position.");
                    
                }
                else
                {
                    invalidInput = false;
                }
            }

           
            x = temporaryCoord[0] - 'A' + 1;
            y = int.Parse(temporaryCoord.Substring(1));

            return new Coordinate(x, y);
        }



        internal static bool ValidCoordinate(string input)
        {
            int columns;
            char rows;

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            bool Valid = char.TryParse(input.Substring(0, 1), out rows);
            Valid = int.TryParse(input.Substring(1), out columns);

            if (rows < 'A' || rows> 'J' || columns <0 || columns >10)
            {
                return false;
            }
            return Valid;
        }



        public static ShipDirection GrabDirection( ShipType sType)
        {
            bool valid = true;
            var direction = ShipDirection.Down;
            while (valid)
            {
               
                

                Console.WriteLine(" Enter a direction for your ship placement:");
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
            return direction;
        }



        internal static string GrabbingName(int num)
        {
            Console.Clear();
            Console.WriteLine($"Enter your player Name {num}: ");
            string playerName = Console.ReadLine();
            return playerName;
        }
        
        //Take the X coordinate from the user
        public static int GrabX(string s)
        {
            int x = -1;

            string letterInteger;
            if (s == "")
            {

                Console.WriteLine($"Not a valid coordinate, change your X!");
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
        public static int GetY(string s)
        {
            //Second coordinate after A-J, 1-10. If greater than 10 or less than 1, give new coordinates.
            int y =-1;
            if (s == "")
            {
                
                Console.WriteLine($"Not a valid coordinate, change your Y!");
            }
            
            else
            {
                int.TryParse(s.Substring(1), out y);
                if (y < 1 || y > 10)
                {

                    Console.WriteLine($"Y coordinate too large or too small!");
                }
            }




            return y;
        }
    }
}
