using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.PageObjects
{
    class ConnectWithBankPageObjects
    {
        public string TTL_ConnectWithBank = "//body//h1[contains(text(),'Connect with bank')]";

        public string DIV_CreatedBankAcctName = "//*[@id='bankaccounts-root']//div[@class='bankaccounts-account--name']";
        public string DIV_CreatedBankAcctNum = "//*[@id='bankaccounts-root']//div[@class='bankaccounts-account--number']";

    }
}
