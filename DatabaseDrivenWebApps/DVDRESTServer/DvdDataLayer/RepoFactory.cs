using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdModelsLayer.Interface;


namespace DvdDataLayer
{
    public static class RepoFactory
    {

        public static IDvdRepository Create()
        {
            string config = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (config)
            {
                case "TestRepository":
                    return new DvdTESTRepo();
                case "EFRepository":
                    return new DvdEFRepo();
                case "ADORepository":
                    return new DvdADORepo();
            }
            return null;
        }
    }
}
