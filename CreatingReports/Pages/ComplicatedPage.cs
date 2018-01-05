using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    public class ComplicatedPage : BaseApplicationPage
    {
        public ComplicatedPage(IWebDriver driver) : base(driver)
        {
        }



        public void GoTo()
        {
            string url = "http://www.ultimateqa.com/complicated-page/";
            Driver.Navigate().GoToUrl(url);
            //Reporter.LogPassingTestStepToBugLogger("Navigate to Complicated Page at url {0}", url);
            Reporter.LogPassingTestStepToBugLogger(string.Format("Navigate to Complicated Page at url {0}", url));
        }

        public bool IsLoaded
        {
            get
            {
                var isLoaded = Driver.Url.Contains("complicated-page");
                Reporter.LogTestStepForBugLogger(Status.Info, "Check whether the complicated page loaded successfully");
                return isLoaded;
            }

        }

        public RandomStuffSection RandomStuffSection
        {
            get
            {
                return new RandomStuffSection(Driver);
            }
        }
    }
}
