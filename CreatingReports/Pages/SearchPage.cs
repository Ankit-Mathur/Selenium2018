using System;
using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    internal class SearchPage : BaseApplicationPage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        internal bool Contains(string itemToCheckFor)
        {
            //Reporter.LogTestStepForBugLogger(Status.Info,"Validate that item {0} exists.", itemToCheckFor);
            Reporter.LogTestStepForBugLogger(Status.Info, string.Format("Validate that item {0} exists.", itemToCheckFor));
                    var isBlouseDisplayed = Driver.FindElement(By.XPath("//*[@title='Blouse']")).Displayed;
                    Logger.Trace("Element found by XPath=>*[@title=\'Blouse\'] isDisplayed=>" + isBlouseDisplayed);
                    return isBlouseDisplayed;
              
        }
    }
}