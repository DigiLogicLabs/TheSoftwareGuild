using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models.Responses;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter a deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine()); //User validation for if they enter a decimal


            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Deposit completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old Balance: {response.OldBalance:C}");
                Console.WriteLine($"Amount Deposited: {response.Amount:C}");
                Console.WriteLine($"New Balance: {response.Account.Balance:C}");
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
