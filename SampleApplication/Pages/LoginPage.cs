using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace SampleApplication.Pages
{
    public class LoginPage:BasePage
    {
        public LoginPage(IWebDriver driver):base(driver){}

        private IWebElement btnLogin
        {
            get
            {
                return Driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
            }
        }

        private IWebElement txtUserName
        {
            get
            {
                return Driver.FindElement(By.Id("txtUserName"));
            }
        }

        private IWebElement txtPassword
        {
            get
            {
                return Driver.FindElement(By.Id("txtPassword"));
            }
        }

        private By toastErrorMessage
        {
            get
            {
                return By.XPath("//div[@class = 'toast-message']");
            }
        }

        public void GoTo()
        {
            string url =  "";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogPassingTestStepToBugLogger(string.Format("In Browser, go to url: {0}", url));
            Assert.IsTrue(IsVisible, "Login page not available to user");
        }

        public bool IsVisible
        {
            get
            {
                Reporter.LogTestStepForBugLogger(Status.Info, "Verify that whether login page loaded successfully");
                return btnLogin.Displayed;
            }
        }

        public CustomDashboardPage Login(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            Reporter.LogPassingTestStepToBugLogger(string.Format("Entered username as: {0}", userName));
            txtPassword.SendKeys(password);
            Reporter.LogPassingTestStepToBugLogger(string.Format("Entered password as: {0}", password));
            btnLogin.Submit();
            Reporter.LogPassingTestStepToBugLogger("Clicked the submit button");

            return new CustomDashboardPage(Driver);
        }

        public bool LoginErrorMessage
        {
            get
            {
                Reporter.LogTestStepForBugLogger(Status.Info, "Verify that user is not able to login");
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                var loginErrorMessage = wait.Until(ExpectedConditions.ElementIsVisible(toastErrorMessage));
                return loginErrorMessage.Displayed;
            }
            }
    }
}
