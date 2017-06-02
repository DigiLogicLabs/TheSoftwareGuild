using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public static class ConsoleOutput

    {
        public static void SplashScreen()
        {
            Console.WriteLine("Welcome to Battle Ship!");

            Console.WriteLine("_____________¶¶¶¶¶¶¶¶¶¶¶¶¶");
            Console.WriteLine("_____________¶¶___________¶¶");
            Console.WriteLine("______________¶____________¶");
            Console.WriteLine("______________¶_____________¶");
            Console.WriteLine("_______________¶____________¶");
            Console.WriteLine("_______________¶____________¶_¶¶");
            Console.WriteLine("_______________¶__¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶");
            Console.WriteLine("_____¶¶¶¶¶¶¶¶¶¶¶¶¶¶______________¶");
            Console.WriteLine("_____¶____________¶¶_____________¶¶____¶");
            Console.WriteLine("_____¶¶____________¶_____¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶");
            Console.WriteLine("______¶______¶¶¶¶¶¶¶¶¶¶¶¶¶¶______________¶");
            Console.WriteLine("______¶¶_____¶¶___________¶______________¶¶");
            Console.WriteLine("_______¶______¶____________¶______________¶");
            Console.WriteLine("_______¶______¶¶___________¶_____________¶¶");
            Console.WriteLine("_______¶_______¶___________¶_____________¶¶");
            Console.WriteLine("______¶¶_______¶___________¶¶____________¶");
            Console.WriteLine("______¶¶¶¶¶¶¶¶¶¶¶__________¶¶___________¶¶");
            Console.WriteLine("___________¶_¶_¶¶________¶¶¶_____¶¶¶¶¶¶¶¶_____¶¶¶");
            Console.WriteLine("___________¶_¶_¶¶¶¶¶¶¶¶¶¶¶_¶¶¶¶¶¶¶_______¶¶¶¶¶__¶¶");
            Console.WriteLine("¶¶¶¶¶¶_____¶_¶______¶¶_¶_______¶_¶¶¶¶¶¶¶¶¶___¶¶¶¶¶");
            Console.WriteLine("¶¶___¶¶¶¶¶¶¶¶¶______¶¶_¶____¶¶¶¶¶¶¶________¶¶");
            Console.WriteLine("__¶¶________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶____¶¶______¶");
            Console.WriteLine("____¶____________________________¶¶_¶____¶");
            Console.WriteLine("_____¶_____¶¶¶_____¶¶_____¶¶¶_____¶¶¶___¶¶");
            Console.WriteLine("______¶___¶¶_¶¶___¶¶_¶____¶_¶¶__________¶");
            Console.WriteLine("_______¶¶_____________________________¶¶");
            Console.WriteLine("________¶¶___________________________¶¶");
            Console.WriteLine("_________¶¶________________________¶¶¶");
            Console.WriteLine("___________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶");

            Console.WriteLine("Press Enter to Start.");
            Console.ReadLine();
        }

        //Board drawn -- needs physical border
        public static void DrawingBoard()
        {
            throw new NotImplementedException();

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

        public static void ErrorNoSpace()
        {
            throw new NotImplementedException();
        }

        public static void ErrorOverLap()
        {
            throw new NotImplementedException();
        }
    }
}
