using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models.Responses;

namespace SGBank.UI.Workflows
{
    public class AccountLookupWorkflow
    {
        public void Execute()
        {
            //First, load the account manager to use to lookup the data
            //The factory is in charge of deciding which interface implementations to use.

            AccountManager manager = AccountManagerFactory.Create(); //Ask the accountmanager factory to fetch us an account manager object.

            Console.Clear();
            Console.WriteLine("Lookup an account");
            Console.WriteLine("--------------------------");
            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            AccountLookupResponse response = manager.LookupAccount(accountNumber); //ask manager to lookup account number that the user entered
            //will send us a response back, response object is a inherited object that has a message and a boolean

            if (response.Success)
            {
                ConsoleIO.DisplayAccountDetails(response.Account);
            }
            else
            {
                Console.WriteLine("An error ocurred: ");
                Console.WriteLine(response.Message);
                
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


        }

        
    }
}
