using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.BLL;
using FloorMastery.Data.Interfaces;
using FloorMastery.Data.Repos;
using FloorMastery.Models;
using NUnit.Framework;

namespace FloorMastery.Tests
{
    [TestFixture]
    public class OrderTest
    {
        //Order#, CustName, State, TaxRate, ProdType, Area, CostpersqFoot, LaborCostprsqFoot, MaterialCost, LaborCost, Tax, Total


//        [TestCase(1, "Conner", "MN", 3.5M, "Wood", 100M, 3.5M, 4.5M, 1.5M, 450M, 15, 900M, false)]
//        [TestCase(1, "Wise", "OH", 6.25M, "Wood", 100M, 5.15M, 4.75M, 515.00M, 475.00M, 61.88M, 1051.88M, true)]

        public void DisplayOrdersTest(string accountNumber, 
        string name, string stateAbbr, decimal taxRate, 
        string productType, decimal area, decimal costPerSqFoot,
        decimal laborCostPerSqFoot, decimal materialCost, 
        decimal laborCost, decimal tax, decimal total, bool isCorrect)

        { }


    }
}
