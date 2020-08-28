using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.PageObjects
{
    //Contains the XPATHs
    class BankAccountsPageObjects
    {
        public string TTL_BankAccounts = "//*[@id='title'][contains(text(),'Bank accounts')]";  //TTL - Title
        public string LNK_AddBankAccount = "//span[contains(text(),'Add Bank Account')]";

        //EXISTING ACCOUNTS
        public string TXT_ExistingAcctName = "//div[@class='document bank-accounts']/div[@class='dashboard-box-inner']//a";
        public string SPN_ExistingAcctNumber = "//div[@class='document bank-accounts']/div[@class='dashboard-box-inner']//a/span";


        //NOTIFICATION
        public string P_NotificationAcctAdded = "//div[@class='document bank-accounts']//div[@class='message']/p";
    }
}