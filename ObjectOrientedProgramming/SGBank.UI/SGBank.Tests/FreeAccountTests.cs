using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.Tests
{
        [TestFixture]
    public class FreeAccountTests
    {
        [Test] // Passed: able to load the free account data from the app.config file
        
        /*public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
            //If this test passes, it means: AccountManagerFactory was able to read the app.config
            //It got the Mode and create the manager object, and our lookup account returned the test data correctly.
        }*/




        [TestCase("12345", "Free Account",100, AccountType.Free,250, false)]
        [TestCase("12345", "Free Account",100, AccountType.Free,-100, false)]
        [TestCase("12345", "Free Account",100, AccountType.Basic,50, false)]
        [TestCase("12345", "Free Account",100, AccountType.Free,50, true)]

        public void FreeAccountDepositRuleTest(string accountNumber,
        string name,
        decimal balance,
        AccountType accountType,
        decimal amount,
        bool expectedResult)
        {

            IDeposit depositRule = new FreeAccountDepositRule();

            Account account = new Account()
            {
               AccountNumber    = accountNumber,
               Name = name,
               Balance = balance,
               Type = accountType,
            };
            AccountDepositResponse response = depositRule.Deposit(account, amount);
            Assert.AreEqual(expectedResult, response.Success);


        }

    }
}
