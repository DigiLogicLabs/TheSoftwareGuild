using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data
{
    //The benefit to using static data fields with hard coded data in test code is that the data will reset when the app restarts.
    //Most test or Mock code that you write, have a few hard coded things that you use.

    public class FreeAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            //now we have a fake account.
            Name = "Free Account",
            Balance = 100.00M,
            AccountNumber = "12345",
            Type = AccountType.Free

        };

        public Account LoadAccount(string AccountNumber)
        {
            if (AccountNumber != _account.AccountNumber)
            {
                return null;
            }
            //When we load account, we don't care what account they give us, giving this one for testing
            return _account;
        }

        public void SaveAccount(Account account)
        {
            //If they save the account, we overwrite the object in the static variable.
            _account = account;
        }
    }
}
