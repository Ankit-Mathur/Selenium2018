using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApplication.Pages
{
    public class SiteInspectionPage:BasePage
    {
        public SiteInspectionPage(IWebDriver driver) : base(driver) { }

        private By HeadingSiteInspection
        {
            get
            {
                return By.XPath("//h4[contains(text(),'Site Inspection')]");
            }
        }

        public bool IsVisible
        {
            get
            {
                WaitUntilPageGetsLoaded();

                var headingSiteInspection = Driver.FindElement(HeadingSiteInspection);
                Reporter.LogTestStepForBugLogger(Status.Info, "Verify that user is taken to Site Inspection page");
                return headingSiteInspection.Displayed;
            }
        }
    }
}
