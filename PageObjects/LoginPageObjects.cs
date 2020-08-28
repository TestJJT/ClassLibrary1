using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.PageObjects
{
    //Contains the XPATHs needed per page
    class LoginPageObjects
    {
        //TB - Text boxes
        public string TB_Email = "//*[@id='email']";  
        public string TB_Password = "//*[@id='password']";

        //BTN - Buttons
        public string BTN_Login = "//*[@id='submitButton']";

        public string SPN_LoginNotifMsg = "//*[@id='root']//span[contains(text(),'Your last login:')]";
    }
}
