using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;
using System.IO;

namespace SGBank.Data.Application
{
    
    public class FileAccountRepository : IAccountRepository
    {
        private const string _filePath = @"C:\Users\Csharpener\Desktop\Repos\conner-soligny-individual-work\SGBank.UI\Accounts.txt";


        public Account LoadAccount(string AccountNumber)
        {
            try
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    reader.ReadLine(); // skip the header
                    string line;


                    while ((line = reader.ReadLine()) != null)
                    {

                        string[] entry = line.Split(',');

                        if (entry [0] == AccountNumber)
                        {

                            return ParseToAccount(entry);
                        }
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error opening up file: " + exception.Message); 
            }
            return null;
        }

        public void SaveAccount(Account account)
        {
            try
            {
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] entriesStrings = line.Split(',');

                        if (entriesStrings[0] == account.AccountNumber)
                        {
                            lines.Add(ParseFromAccount(account));
                        }
                        else
                        {
                            lines.Add(line);
                        }
                    }
                    
                }
                File.WriteAllLines(_filePath, lines);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error saving to File: " + exception.Message);
                
            }
            
        }

        private Account ParseToAccount(string[] entry)
        {
            AccountType type;

            switch (entry[3])
            {
                case "F":
                    type = AccountType.Free;
                    break;

                case "B":
                    type = AccountType.Basic;
                    break;
                case "P":
                    type = AccountType.Premium;
                    break;
                default:
                    throw new Exception("Account Type doesn't match");
            }
            return new Account()
            {
                AccountNumber = entry[0],
                Name = entry[1],
                Balance = decimal.Parse(entry[2]),
                Type = type
            };

        }
        private string ParseFromAccount(Account account)
        {
            return $"{account.AccountNumber},{account.Name},{account.Balance},{account.Type.ToString()[0]}";
        }
    }
}
