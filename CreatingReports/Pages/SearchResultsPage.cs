using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    public class SearchResultsPage :BaseApplicationPage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLoaded
        {
            get
            {
                return Driver.Url.Contains("?s");
            }
        }
    }
}