using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApplication.Pages
{
    public class CustomDashboardPage:BasePage
    {
        public CustomDashboardPage(IWebDriver driver) : base(driver) { }

        private IWebElement headingCustomDashboard
        {
            get
            {
                return Driver.FindElement(By.XPath("//h4[contains(text(),'Dashboard')]"));
            }
        }

          public bool IsVisible
        {
            get
            {
                WaitUntilPageGetsLoaded();
                Reporter.LogTestStepForBugLogger(Status.Info, "Verify whether user was able to login successfully");
                return headingCustomDashboard.Displayed;
            }
        }

          public SiteInspectionPage GoToSiteInspection()
          {
              Driver.Navigate().GoToUrl("");
              Reporter.LogPassingTestStepToBugLogger("Clicked on New Site Inspection sub-menu");
              return new SiteInspectionPage(Driver);
          }
    }
}
