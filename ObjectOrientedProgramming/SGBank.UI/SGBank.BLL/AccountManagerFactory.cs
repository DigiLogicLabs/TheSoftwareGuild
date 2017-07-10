using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Data.Application;

namespace SGBank.BLL
{
     public static class AccountManagerFactory
     {
        //Most factory classes name their primary method Create() since it creates an object.
         public static AccountManager Create()
            //reference added in assemblies(.NET framework) = system.configuration has a Class in it ConfigurationManager which reads your .config file
         {
             string mode = ConfigurationManager.AppSettings["Mode"].ToString(); //Opens up appconfig, and looks at app setting and pulls value assigned to the Mode key and puts it into the string

             switch (mode)
             {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                case "BasicTest":
                    return new AccountManager(new BasicAccountTestRepository());
                case "PremiumTest":
                    return new AccountManager(new PremiumAccountTestRepository());
                case "Accounts.txt":
                    return new AccountManager(new FileAccountRepository());

                default:
                    throw new Exception("Mode value in app config is not valid ");
             }
         }
     }
}
