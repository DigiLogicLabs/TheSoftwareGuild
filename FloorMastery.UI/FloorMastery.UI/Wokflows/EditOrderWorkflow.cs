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


            var orderDateInput = Console.ReadLine();
        }
    }
}