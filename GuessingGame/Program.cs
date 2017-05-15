using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer = 0;
            int playerGuess; 
            string playerInput;
            string playerName;
            int counter = 0;
            bool invalidDifficulty = true;

            Random r = new Random();
            theAnswer = r.Next(1, 21);

            int theDifficulty;

            
            
            //Difficulty levels and range
            do
            {
                Console.WriteLine("Choose a difficulty: ");
                Console.WriteLine("1 = Peasant (1-5), 2 = Knight (1-30), 3 = King (1-100)");
                string difficulty = Console.ReadLine();

                if (difficulty == "1")
                {
                    theDifficulty = r.Next(1, 5);
                    break;
                }
                else if (difficulty == "2")
                {
                    theDifficulty = r.Next(1, 30);
                    break;
                }
                else if (difficulty == "3")
                {
                    theDifficulty = r.Next(1, 100);
                    break;
                }
                else
                {
                    Console.WriteLine("That's PEASANT info, please try again.");
                }
            } while (true);
            
            


            //Enter name
            Console.WriteLine("Enter your name: ");
            playerName = Console.ReadLine();
           
           
            //Start game
            do
            {
              
                // get player input
                Console.Write($"{playerName} Enter your guess, or perish with the peasants!! ");
                playerInput = Console.ReadLine();
                counter++;
                Console.WriteLine($"Turn: {counter}");
                if (playerInput == "Q")
                {
                    break;
                }
                
                
                //attempt to convert the string to a number

                if (int.TryParse(playerInput, out playerGuess))
                {
                    
                    if (playerGuess == theDifficulty)
                    {
                        Console.WriteLine($"{theAnswer} was the number...HAIL TO THE KING BABY!");
                        break;
                    }
                    else
                    {
                        if (playerGuess > theDifficulty)
                        {
                            Console.WriteLine($"{playerName} Your guess was too High!");
                        }
                        else
                        {
                            Console.WriteLine($"{playerName} Your guess was too low!");
                        }
                    }
                }

                //Promt User for Number
                else
                {
                    Console.WriteLine($"{playerName} That wasn't a number!");
                }

            } while (true);

            Console.WriteLine($"{playerName} Press any key to quit.");
            Console.ReadKey();
        }
    }
}
