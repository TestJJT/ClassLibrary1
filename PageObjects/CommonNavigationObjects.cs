using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.PageObjects
{
    //Contains the XPATHs
    class CommonNavigationObjects
    {
        //NAVIGATION TAB GROUP
        public string BTN_Accounting = "//*[@id='header']/header//button[contains(text(),'Accounting')]";

        public string LNK_BankAccounts = "//*[@id='header']/header//a[contains(text(),'Bank accounts')]";
        public string LNK_ChartOfAccounts = "//*[@id='header']/header//a[contains(text(),'Chart of accounts')]";
        
        public string LNK_UserLogout = "//*[@id='header']/header//a[contains(text(), 'Log out')]";

        public string ABR_UserAvatar = "//*[@id='header']/header//abbr";
        
       
    }
}
