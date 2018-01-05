using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    internal class HomePage : BaseApplicationPage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        public Slider Slider { get; internal set; }
        public bool IsLoaded {

            get
            {
                var isLoaded = Driver.Url.Equals("http://automationpractice.com/index.php");
                Reporter.LogTestStepForBugLogger(Status.Info, "Validate whether the Home Page loaded successfully.");
                _logger.Trace("Home page is loaded ",isLoaded);
                return isLoaded;
            }
        }

        public HeaderSection Header 
        {
            get
            {
                return new HeaderSection(Driver);
            }
        }

        internal void GoTo()
        {
            string url = "http://automationpractice.com";
            Driver.Navigate().GoToUrl(url);
            //Reporter.LogPassingTestStepToBugLogger("In a browser, go to url", url);
            Reporter.LogPassingTestStepToBugLogger(string.Format("In a browser, go to user {0}", url));
        }

        internal SearchPage Search(string itemToSearchFor)
        {
            _logger.Trace("Attempting to perform a Search.");
            Driver.FindElement(By.Id("search_query_top")).SendKeys(itemToSearchFor);
            Driver.FindElement(By.Name("submit_search")).Click();
           // Reporter.LogTestStepForBugLogger(Status.Info,"Search for {0} in the search bar on the page.", itemToSearchFor);
            Reporter.LogTestStepForBugLogger(Status.Info, string.Format("Search for {0} in the search bar on the page.", itemToSearchFor));
            //_logger.Info($"Search for an item in the search bar=>{itemToSearchFor}");
            return new SearchPage(Driver);
        }
    }
}