using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.PageObjects
{
    class AddBankAccountsPageObjects
    {
        public string TTL_AddBankAccounts = "//*[@id='common-page-title-1005'][contains(text(),'Add Bank Accounts')]";

        public string LNK_ANZOption = "//li[contains(text(),'ANZ (NZ)')]";

        public string HED_EnterANZDetails = "//h1[@class='ba-page-title'][contains(text(),'Enter your ANZ (NZ) account details')]";

        public string DRP_AccountType = "//*[@id='accounttype-1039-inputEl']";

        public string TB_AccountName = "//*[@id='accountname-1037-inputEl']";
        public string TB_AccountNumber = "//*[@id='accountnumber-1068-inputEl']";
        public string TB_CC_AccountNumber = "//*[@id='accountnumber-1063-inputEl']";
        
        public string BTN_Continue = "//*[@id='common-button-submit-1015-btnInnerEl']";

        public string LI_AcctTypeOption = "//*[@id='boundlist-1076-listEl']/li[contains(text(),'";

    }
}
