using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.DepositRules
{
    //since BLL is in charge of enforcing rules
    public class FreeAccountDepositRule : IDeposit
    {

        public AccountDepositResponse Deposit(Account account, decimal amount) //this says, they will give us account, were going to figure out what to do with it
        {
            AccountDepositResponse response = new AccountDepositResponse();

            if (account.Type != AccountType.Free) //Checking to be sure it's a freeaccount
            {
                response.Success = false;
                response.Message = "Error: A non free account hit the Free Deposit Rule. Contact IT";
                return response;
            }
            if (amount > 100)
            {
                response.Success = false;
                response.Message = "Free accounts cannot deposit more than $100 at a time"; //if amount is greater than what is aloud, then we stop
                return response;
            }
            if (amount <= 0)
            {
                response.Success = false;
                response.Message = "Deposit amounts must be greater than zero"; //if amount doesn't make sense like a negative or 0, then we stop
                return response;
            }
            //If we get through these 3 rules, we're okay to do the deposit.
            
            response.OldBalance = account.Balance; 
            account.Balance += amount; // account balance gets added the amount they want to deposit
            response.Account = account; //we can put that account into the response object
            response.Amount = amount; //also want to put the amount deposited into the response object
            response.Success = true;

            return response;
        }
    }
}
