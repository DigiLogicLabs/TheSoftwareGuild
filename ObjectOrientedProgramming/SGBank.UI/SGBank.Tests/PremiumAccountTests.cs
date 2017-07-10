using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.Tests
{
    [TestFixture]

    public class PremiumAccountTests
    {

        [TestCase("13371", "Premium Account", 1000000, AccountType.Premium,-100, false)]
        [TestCase("42411", "Premium Account", 1050, AccountType.Premium, -100, false)]
        [TestCase("14447", "Premium Account", 1100, AccountType.Basic, 250, true)]

        public void PremiumAccountDepositRuleTest(string accountNumber,
            string name,
            decimal balance,
            AccountType accountType,
            decimal amount,
            bool expectedResult)
        {
            IDeposit noLimitRule = new NoLimitDepositRule();

            Account account = new Account()
            {
                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType,
            };

            AccountDepositResponse response = noLimitRule.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }

        [TestCase("13371", "Premium Account", 1000000, AccountType.Premium, -100000, 900000, false)]
        [TestCase("14142", "Premium  Account", 11150, AccountType.Premium, -100, 100, false)]
        [TestCase("19191", "Premium Account", 1000000, AccountType.Premium, -150, -60, false)]

        public void PremiumAccountWithdrawRuleTest(string accountNumber,
            string name,
            decimal balance,
            AccountType accountType,
            decimal amount, decimal newBalance,
            bool expectedResult)
        {
            IWithdraw withdrawRule = new PremiumAccountWithdrawRule();

            Account account = new Account()
            {
                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType

            };
            AccountWithdrawResponse response = withdrawRule.Withdraw(account, amount);
            Assert.AreEqual(expectedResult, response.Success);
            if (response.Success)
            {
                Assert.AreEqual(newBalance, response.Account.Balance);
            }

        }
    }
}
