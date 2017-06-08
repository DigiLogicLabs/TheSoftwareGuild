using System;
namespace FloorMastery.UI.Wokflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("     ╔═══════════════════════════════╗");
            Console.WriteLine("     ║           Edit Orders         ║");
            Console.WriteLine("     ╚═══════════════════════════════╝");
            Console.WriteLine("           Press Enter To Start:      ");
            Console.ReadLine();
            Console.Write("Enter Date of Order (SimpleDateFormat (MM-dd-yyyy)): ");


            
            var orderEdit = Console.ReadLine();

            DateTime result;

            if (DateTime.TryParse(orderEdit, out result))
            {
                return;
            }
            if (orderEdit == "")
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
        }
    }
}