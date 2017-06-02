using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        public Account LoadAccount(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
