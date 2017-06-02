using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class PremiumAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error: A non Premium account hit the Premium Withdrawal Rule. Contact IT";
                return response;
            }
            if (account.Balance + amount < 0)
            {
                response.Success = false;
                response.Message = $"Your account has insufficient funds for that withdrawal amount";
                return response;
            }
            if (amount >= 0)
            {
                response.Success = false;
                response.Message = $"Withdrawal amounts must be a negative number!";
                return response;
            }
            if (amount < -100000)
            {
                response.Success = false;
                Console.WriteLine(
                    $"Premium accounts cannot withdraw more than $100,000 at a time... What do you even need that for?!!!");
                return response;

            }
            return response;
        }
    }
}
