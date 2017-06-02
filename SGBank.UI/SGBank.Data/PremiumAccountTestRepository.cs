using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data
{
    public class PremiumAccountTestRepository :IAccountRepository
    {
        private static Account _account = new Account
        {
            //now we have a fake account.
            Name = "Premium Account",
            Balance = 1000000.00M,
            AccountNumber = "13371",
            Type = AccountType.Premium

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
