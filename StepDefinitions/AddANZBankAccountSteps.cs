using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using ClassLibrary1;
using System.Threading;
using ClassLibrary1.PageObjects;
using ClassLibrary1.StepDefinitions;

namespace ClassLibrary1.StepDefinitions
{ 


    [Binding]
    public class AddANZBankAccountSteps
    {
    public IWebDriver driver;
    Config.Account account;
    
    PageObjects.AddBankAccountsPageObjects AddBankAccountsPage;
    PageObjects.BankAccountsPageObjects BankAccountsPage;
    PageObjects.CommonNavigationObjects Navigation;
    PageObjects.ConnectWithBankPageObjects ConnectWithBank;

    [Given(@"the user is logged in")]
    public void GivenTheUserIsLoggedIn()
    {

        LaunchBrowser();
        Login();

    }

    [When(@"the user adds ANZ\(NZ\) ""(.*)"" account with account number ""(.*)"" named ""(.*)""")]
    public void WhenTheUserAddsANZNZAccountWithAccountNumberNamed(string acctType, string acctNumber, string acctName)
    {
            var timestamp = DateTime.Now;
            account = new Config.Account();
            account.AccountName = acctName + timestamp.ToString("MMddyyyyHHmmss") ;
            account.AccountNumber = acctNumber;
            account.AccountType = acctType;
            

            Navigation = new PageObjects.CommonNavigationObjects();
            BankAccountsPage = new PageObjects.BankAccountsPageObjects();
            AddBankAccountsPage = new PageObjects.AddBankAccountsPageObjects();

            //Click Accounting
            ClickElement(Navigation.BTN_Accounting);

            //Click Bank Accounts
            ClickElement(Navigation.LNK_BankAccounts);

            //Validate that the user is in the "Bank Accounts" Page, Title exists
            driver.FindElement(By.XPath(BankAccountsPage.TTL_BankAccounts));

            //Click "Add Bank Account"
            ClickElement(BankAccountsPage.LNK_AddBankAccount);

            //Validate title = Add Bank Accounts
            driver.FindElement(By.XPath(AddBankAccountsPage.TTL_AddBankAccounts));

            //Select ANZ from Popular NZ banks list
            ClickElement(AddBankAccountsPage.LNK_ANZOption);

            //Validate header for new ANZ add account
            driver.FindElement(By.XPath(AddBankAccountsPage.HED_EnterANZDetails));

            //Enter Account Name
            EnterText(AddBankAccountsPage.TB_AccountName, account.AccountName);

            //Select Account Type
            ClickElement(AddBankAccountsPage.DRP_AccountType);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(AddBankAccountsPage.LI_AcctTypeOption + account.AccountType + "')]")).Click();
            Thread.Sleep(500);

           
            //Enter the account number
            if (account.AccountType == "Credit Card") {
                
                //Click last 4 digit area first, to make element actionable
                 ClickElement(AddBankAccountsPage.TB_CC_AccountNumber);
                 Thread.Sleep(500);
                 EnterText(AddBankAccountsPage.TB_CC_AccountNumber, account.AccountNumber);
               
            }
            else
            {
                EnterText(AddBankAccountsPage.TB_AccountNumber, account.AccountNumber);
            }

        Thread.Sleep(1000);     //Causing intermittent invalid account number

        //Click Continue
        ClickElement(AddBankAccountsPage.BTN_Continue);
        Thread.Sleep(2000);


        }




     [Then(@"the account should be saved and Connect with Bank suggested to user")]
     public void ThenTheAccountShouldBeSavedAndConnectWithBankSuggestedToUser()
        {

            ConnectWithBank = new PageObjects.ConnectWithBankPageObjects();

            //Validate "Connect with Bank" Page is displayed with the added account name and account number
            driver.FindElement(By.XPath(ConnectWithBank.DIV_CreatedBankAcctName));
            driver.FindElement(By.XPath(ConnectWithBank.DIV_CreatedBankAcctNum));


            //Click Accounting
            ClickElement(Navigation.BTN_Accounting);

            //Click Bank Accounts
            ClickElement(Navigation.LNK_BankAccounts);

            Thread.Sleep(1000);
            
            //Validate that account is listed under Bank accounts
            CheckAccountIsInBankAccounts();


            //Logout and close the browser
            Thread.Sleep(1000);
            Logout();
    }

        
            [Then(@"the account should be saved and displayed under Bank Accounts")]
            public void ThenTheAccountShouldBeSavedAndDisplayedUnderBankAccounts()
            {
                //Validate - Notification is displayed
                //Account name added.
                driver.FindElement(By.XPath(BankAccountsPage.P_NotificationAcctAdded + "[contains(text(),'" + account.AccountName + " added.  Xero works better with your transactions.  Get started by ')]"));

                //Validate that account is listed under Bank accounts
                CheckAccountIsInBankAccounts();

                //Logout and close the browser
                Thread.Sleep(1000);
                Logout();

        }
        
        
        public void ClickElement(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Click();
        }

        public void EnterText(string xpath, string text)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(text);
        }

        public void GoToEndpoint(string endpoint)
        {
            driver.Navigate().GoToUrl(endpoint);
        }

        public void LaunchBrowser()
        {

            //Launch Browser, new instance of Chrome
            driver = new ChromeDriver();

            //Set pre-req wait to have buffer time for loading before performing an action on an element
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        
       
        public void Login()
        {

            var data = new Config.EnvironmentProperties();
            var testuser = new Config.TestUser();


            var Login = new PageObjects.LoginPageObjects();


            //Navigate to login page
            GoToEndpoint(data.endpoint);

            //Enter the user's credentials
            EnterText(Login.TB_Email, testuser.email);
            EnterText(Login.TB_Password, testuser.password);

            //Click Log in button
            ClickElement(Login.BTN_Login);


            //Validate Login
            //User avatar element exists
            driver.FindElement(By.XPath(Login.SPN_LoginNotifMsg));
           
        }

        public void Logout()
        {


            //Click user avatar
            Thread.Sleep(1000);
            ClickElement(Navigation.ABR_UserAvatar);
           

            //Click Log out
            Thread.Sleep(1000);
            ClickElement(Navigation.LNK_UserLogout);

            //Validate that logout is successful, Login button exist
            var Login = new PageObjects.LoginPageObjects();
            driver.FindElement(By.XPath(Login.BTN_Login));

            //Close the browser driver
            Thread.Sleep(1000);     //Just for tester to see
            driver.Quit();


        }

        public void CheckAccountIsInBankAccounts()
        {
            //Validate that added account is saved/displayed
            //There are elements that contain the account number and account name used
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(BankAccountsPage.TXT_ExistingAcctName + "[contains(text(),'" + account.AccountName + "')]"));
            driver.FindElement(By.XPath(BankAccountsPage.SPN_ExistingAcctNumber + "[contains(text(),'" + account.AccountNumber + "')]"));

        }
    }
}
