using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.DepositRules
{
    public class PremiumAccountDepositRules : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();
            if (account.Type!= AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error: A non Premium account hit the Premium Deposit Rule. Contact IT";
                return response;
            }
            if (amount <= 0)
            {
                response.Success = false;
                response.Message =
                    "Premium deposit amounts must be positive"; //if amount is greater than what is aloud, then we stop
                return response;
                
            }
            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;

            return response;
        }
    }
}
