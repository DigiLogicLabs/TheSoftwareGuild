using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.BLL.DepositRules
{
    public class DepositRulesFactory
    {
        public static IDeposit Create(AccountType type) //code to interfaces, not implementations
        {
            switch (type)
            {
                    case AccountType.Free:
                    return new FreeAccountDepositRule();
                    case AccountType.Basic:
                    return new NoLimitDepositRule();
            }
            throw new Exception("Account type is not supported!"); // another error message, right now we may get it, but once we are live with all account types, that error should never happen
        }
    }
}
