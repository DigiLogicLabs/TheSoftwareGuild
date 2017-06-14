using System;
using System.Collections.Generic;
using FloorMastery.Data.Interfaces;
using FloorMastery.Data.Repos;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;

namespace FloorMastery.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {

            Console.Clear();
            ConsoleIO.PrintAddHeader();


            //convert the date with "\" or "-" inbetween, filters through and then compares it to a .txt file path
            //if there isn't one, I need to allow the creation of one that can store data
            

        }
    }
}