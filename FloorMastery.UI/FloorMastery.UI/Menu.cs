using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.UI.Wokflows;

namespace FloorMastery.UI
{
    public class Menu
    {
        public static void Start()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("********************************************");
                Console.WriteLine("Flooring Program");
                Console.WriteLine("*");
                Console.WriteLine("*1.Display Orders");
                Console.WriteLine("*2.Add an Order");
                Console.WriteLine("*3.Edit an Order");
                Console.WriteLine("*4.Remove an Order");
                Console.WriteLine("*5.Quit");
                Console.WriteLine("*");
                Console.WriteLine("********************************************");
                Console.Write("\nEnter selection: ");

                Console.ReadLine();


                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        DisplayOrderWorkflow displayWorkflow = new DisplayOrderWorkflow();
                        displayWorkflow.Execute(); //Loads accountmanager from factory, no matter what's put in, we should get our freeaccount object back
                        break;
                    case "2":
                        AddOrderWorkflow addWorkflow = new AddOrderWorkflow();
//                        addWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editWorkflow = new EditOrderWorkflow();
//                        editWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeWorkflow = new RemoveOrderWorkflow();
//                        removeWorkflow.Execute();
                        break;
                        
                    case "5":
                        return;
                }
            }
        }
    }
}
