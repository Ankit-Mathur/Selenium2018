using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    public class LeftPageSection : BaseApplicationPage
    {
        public LeftPageSection(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement SearchForm 
        {
            get
            {
                return Driver.FindElements(By.XPath("//form[@role='search']"))[1];
            }
        }
        public IWebElement SearchBox 
        {
            get
            {
                return Driver.FindElements(By.XPath("//form[@role='search']//input[@id='s']"))[0];
            }
        }
        public IWebElement SearchButton 
        {
            get
            {
                return SearchForm.FindElement(By.Id("searchsubmit"));
            }
        }

        public SearchResultsPage Search(string searchString)
        {
            SearchBox.SendKeys(searchString);
            SearchButton.Click();
            //Reporter.LogPassingTestStepToBugLogger("Serach for string=>{0} in the left pane's Search bar.", searchString);
            Reporter.LogPassingTestStepToBugLogger(string.Format("Search for string {0} in the left pane's Search bar.", searchString));
            return new SearchResultsPage(Driver);
        }
    }
}