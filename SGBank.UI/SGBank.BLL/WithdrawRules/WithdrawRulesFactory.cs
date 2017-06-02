using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL.DepositRules;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.BLL.WithdrawRules
{
   public class WithdrawRulesFactory
    {
        public static IWithdraw Create(AccountType type) //code to interfaces, not implementations
        {
            switch (type)
            {
                    case AccountType.Free:
                    return new FreeAccountWithdrawRule();
                    case AccountType.Basic:
                    return new BasicAccountWithdrawRule();
            }
            throw new Exception("Account type is not supported!");
        }
        
    }
}
