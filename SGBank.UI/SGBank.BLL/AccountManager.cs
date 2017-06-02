using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL
{
    //To do its job, it needs to load and save data(which is what our repositories will do)

    public class AccountManager
    {
        //BLL is the account manager, heart of the application, all the rules in here. 
        //Account manager takes what comes in from UI, try to do stuff with repository, and make sure all rules are applied in correct order

        private IAccountRepository _accountRepository;

        //Added this private repository called _accountRepository.

            //account manager can't operate without a repository, added a constructor (constructor injection) 
            //forcing whoever instantiate Accountmanager to provide an accountRepository, whatever is provided, we will save it into a field to use for later
        public AccountManager(IAccountRepository accountRepository) //our repository is dependency injected because we are going to use the same one
        {
            _accountRepository = accountRepository;
        }
        //Wrapping your model in another class allows you to send additional information to the caller like error and status messages. Returning account lookup response
        //given account number, we will return an accountlookupresponse.

        public AccountLookupResponse LookupAccount(string accountNumber)
        {
            AccountLookupResponse response = new AccountLookupResponse();
            //Instantiate lookup response because that's what we want to return
            response.Account = _accountRepository.LoadAccount(accountNumber);
            //Ask accountrepository to load account with the account number that was given

            if (response.Account == null) //Gave us account number that doesn't exist
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public AccountDepositResponse Deposit(string accountNumber, decimal amount) //this will depend on which account number they give us
        {
            AccountDepositResponse response = new AccountDepositResponse(); 

            response.Account = _accountRepository.LoadAccount(accountNumber);
            

            if (response.Account == null) //Gave us account number that doesn't exist
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
                return response;
            }
            else
            {
                response.Success = true;
            }

            //this deposit rule, which one we pick,  will change repeatedly as the application runs. Coding against interfaces.
            IDeposit depositRule = DepositRulesFactory.Create(response.Account.Type);//Loading the rule, asking our deposit rule factory to get us a rule for the account type.

            response = depositRule.Deposit(response.Account, amount);//response equal to deposit, the account that we loaded and amount that we want to deposit

            if (response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }
            return response;
        }


        public AccountWithdrawResponse Withdraw(string accountNumber, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

           response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
                return response;
            }

            IWithdraw withdrawRule = WithdrawRulesFactory.Create(response.Account.Type);
            response = withdrawRule.Withdraw(response.Account, amount);
            if (response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }

            return response;
        }
    }
}
