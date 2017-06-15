
using System;
using System.Threading;
using FloorMastery.Models.Helpers;
using FloorMastery.UI.Workflows;
using FloorMastery.BLL;
using FloorMastery.BLL.Factories;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models.Responses;

namespace FloorMastery.UI
{
    
    public class Menu
    {
        
         
//        public Menu(IOrderRepository order, IProductRepository product, ITaxesRepository taxes)
//        {
//            _orderManager = new OrderManager(order);
//            _productManager = new ProductManager(product);
//            _taxesManager = new TaxesManager(taxes);
//        }


        public static void Start()
        {
            while (true)
            {
                ConsoleIO.PrintMainMenu();
                
                string userinput = Console.ReadLine();
                if (userinput == "")
                {
                    Console.Clear();
                    Start();
                }

                switch (userinput)
                {
                    case "1":
                        DisplayOrderWorkflow displayWorkflow = new DisplayOrderWorkflow();
                        displayWorkflow.Execute(); //Loads accountmanager from factory, no matter what's put in, we should get our freeaccount object back
                       
                        break;

                    case "2":
                        AddOrderWorkflow addWorkflow = new AddOrderWorkflow();
                        addWorkflow.Execute();
                        break;

                    case "3":
                        EditOrderWorkflow editWorkflow = new EditOrderWorkflow();
                        editWorkflow.Execute();
                        break;

                    case "4":
                        RemoveOrderWorkflow removeWorkflow = new RemoveOrderWorkflow();
                        removeWorkflow.Execute();
                        break;

                    case "5":   
                    case "Q":
                    case "q":
                        Console.ReadKey();
                        return;



                }
            }
        }
    }
}