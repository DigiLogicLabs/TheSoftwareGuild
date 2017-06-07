using System;

namespace FloorMastery.UI.Wokflows
{
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("     ╔═══════════════════════════════╗");
            Console.WriteLine("     ║        Display Orders         ║");
            Console.WriteLine("     ╚═══════════════════════════════╝");
            Console.WriteLine("           Press Enter To Start:      ");
            Console.ReadLine();
            Console.Write("Enter Date of Order (SimpleDateFormat (MM-dd-yyyy)): ");
            var orderDateInput = Console.ReadLine();


            DateTime result;

            if (DateTime.TryParse(orderDateInput, out result))
            {
                return;
            }
            if (orderDateInput == "")
            {
                Console.WriteLine("Can't convert a blank string to a Date!");
                Console.ReadKey();
                Console.Clear();
                Menu.Start();
            }
            else
            {
                Console.WriteLine("Please enter an order date in SimpleDateFormat (MM-dd-yyyy) ");
                Console.WriteLine();
                Console.WriteLine("Press Enter to try again...");
                Console.ReadLine();
                Execute();
            }
            Console.Clear();
            return;
            { 
            // string correctFormat = $"{String.Format("MM-dd-yyyy")}";

//            while (orderDateInput != correctFormat)
//            {
//                Console.WriteLine("Date is invalid");
//
//                Console.ReadLine();
//                Console.WriteLine("Enter an order date in SimpleDateFormat (MM-dd-yyyy)");
//                
//                if (orderDateInput == "")
//                {
//                    Console.WriteLine("Can't convert a blank string...");
//                    Console.ReadLine();
//                    Console.Clear();
//
//
//                }
//
//                if (orderDateInput == correctFormat)
//                {
//                    break;
//                }
//            }
            }


    }

        //                AccountManager accountManager = AccountManagerFactory.Create();
        //
        //                Console.Write("Enter an account number: ");
        //                string accountNumber = Console.ReadLine();
        //
        //                Console.Write("Enter a deposit amount: ");
        //                decimal amount = decimal.Parse(Console.ReadLine()); //User validation for if they enter a decimal

        //                AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);
        //
        //                if (response.Success)
        //                {
        //                    Console.WriteLine("Deposit completed!");
        //                    Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
        //                    Console.WriteLine($"Old Balance: {response.OldBalance:C}");
        //                    Console.WriteLine($"Amount Deposited: {response.Amount:C}");
        //                    Console.WriteLine($"New Balance: {response.Account.Balance:C}");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("An error occurred: ");
        //                    Console.WriteLine(response.Message);
        //                }
    }
}