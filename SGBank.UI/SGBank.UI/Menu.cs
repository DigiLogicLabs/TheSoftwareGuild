using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.UI.Workflows;

namespace SGBank.UI
{
    //This is an example of a class that doesn't have a state and only will ever have one of them runnning, that's why we can make it static
    public class Menu
    {
        public static void Start()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SG Bank Application");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Lookup an Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdrawl");

                Console.WriteLine("\nQ to quit");
                Console.Write("\nEnter selection: ");

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        AccountLookupWorkflow lookupWorkflow = new AccountLookupWorkflow();
                        lookupWorkflow.Execute(); //Loads accountmanager from factory, no matter what's put in, we should get our freeaccount object back
                        break;
                    case "2":
                        DepositWorkflow depositWorkflow = new DepositWorkflow();
                        depositWorkflow.Execute();
                        break;
                    case "3":
                        WithdrawWorkflow withdrawWorkflow = new WithdrawWorkflow();
                        withdrawWorkflow.Execute();
                        break;
                    case "Q":
                        return;
                }
            }
        }
    }
}
