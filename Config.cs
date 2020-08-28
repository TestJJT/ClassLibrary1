using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Config
    {
        public class TestUser
        {
            public string email = "testuser01jjt@gmail.com";
            public string password = "Test!pass123";
        }

        public class EnvironmentProperties
        {
            public string endpoint = "https://login.xero.com/";

        }

        public class Account
        {

            public string AccountName;
            public string AccountNumber;
            public string AccountType;
        }
    }
}
