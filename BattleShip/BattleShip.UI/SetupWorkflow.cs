using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.UI;
using BattleShip.BLL.Ships;
using System;

namespace BattleShip.UI
{
    public class SetupWorkflow
    {
        public Player P1 { get; set; }
        public Player P2 { get; set; }

        public bool P1First { get; set; }

        //First we'd like to start with a game menu

        public void Start()

        {
            
            P1First = RNG.FlipCoin();
           // P1.Name 
        }

       

        private void PlaceShips(Board toSetUp)
        {
            for (var sType = ShipType.Destroyer; sType <= ShipType.Carrier; sType++)
            {
                if (P1First)
                {
                }
            }

            throw new NotImplementedException();
        }

        //Present the board and ask for Ship placement(Can't go outside of board parameters)
        //Each player takes a turn placing the ships on the board (starting pos, and direction to place)
        public void GetInfoFromPlayer()
        {
           // var name = PlayerInput.GetName();
        }

        //Ask the users for name inputs (2players(a,b)) & store those values for message references.
        public void PlayerPlaceShip()
        {
        }

        //Randomize which player goes first, present a blank board to the first player
        //Players pick a coordinate ((A-J) & (1-10) = x,y)
        public void GameStatus()
        {
        }

        //Shots fired on the coordinates given, if miss 'M' in yellow
        //If shot hits, place a red 'H'. Same spot shot gives user a retry until unmarked position is hit
        public void GameWon()
        {
        }

        //If ship is sunk, prompt user which ship was sunk, all ships sunk = player() wins the game, promt New Game or Quit Game
    }
}