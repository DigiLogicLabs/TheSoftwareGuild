using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.UI;
using BattleShip.BLL.Ships;
using System;
using System.Security.Cryptography.X509Certificates;
using BattleShip.BLL.Player;

namespace BattleShip.UI
{
    public class SetupWorkflow
    {
        public Player P1 { get; private set ; }
        public Player P2 { get; private set; }
        public bool P1Turn { get; private set; }


        //First we'd like to start with a game menu

        public void BeginningGameInfo()
        {
            P1 = GetInfoFromPlayer(1);
            P2 = GetInfoFromPlayer(2);

            P1Turn = RNG.FlipCoin();
            
        }

        public void PlaceShip(Board pBoard, ShipType sType)
        {
            
            bool successfulPlacement = false;
            
            
                while (successfulPlacement == false)
                {
                    PlaceShipRequest request = new PlaceShipRequest();

                    request.ShipType = sType;
                    Console.WriteLine("Please enter your starting coordinates for ship placement. (A-J)+(1-10)");
                    request.Coordinate = ConsoleInput.GrabCoordinate();
                    request.Direction = ConsoleInput.GrabDirection(sType);


                    ShipPlacement response = pBoard.PlaceShip(request);

                    
                    
                        if (response == ShipPlacement.Ok)
                        {
                            successfulPlacement = true;
                            Console.Clear();
                        }
                        else
                        {
                            ConsoleOutput.ErrorNoSpaceOrOverlap(response);
                        }
                    

                 }

            
        }

        //Present the board and ask for Ship placement(Can't go outside of board parameters)
        //Each player takes a turn placing the ships on the board (starting pos, and direction to place)
        private  Player GetInfoFromPlayer(int num)
        {
            string name = PlayerName(num);
            Player p = new Player(name);
            PlayerBoardCreate(p.PBoard);



            return p;
        }

       

        //Ask the users for name inputs (2players(a,b)) & store those values for message references.
        public string PlayerName(int num)
        {
            return ConsoleInput.GrabbingName(num);
        }

        //Randomize which player goes first, present a blank board to the first player
        //Players pick a coordinate ((A-J) & (1-10) = x,y)
        public void PlayerBoardCreate(Board pBoard)
        {
            for (ShipType sType = ShipType.Destroyer; sType <= ShipType.Carrier; sType++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                PlaceShip(pBoard, sType);
                Console.WriteLine($"You've placed {sType} successfully");
                
            }
        }

        //Shots fired on the coordinates given, if miss 'M' in yellow
        //If shot hits, place a red 'H'. Same spot shot gives user a retry until unmarked position is hit
        
    }
}