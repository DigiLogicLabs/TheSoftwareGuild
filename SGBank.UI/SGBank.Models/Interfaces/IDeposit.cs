using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Responses;

namespace SGBank.Models.Interfaces
{
    public interface IDeposit
    {
        //We now have an interface (IDeposit), that requires one method (deposit) takes an account and takes amount returns some kind of response status to let the account manager and UI know if it was good or not.
        AccountDepositResponse Deposit(Account account, decimal amount);
    }
}
