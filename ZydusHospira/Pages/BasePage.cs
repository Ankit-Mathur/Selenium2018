using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApplication.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public bool WaitUntilPageGetsLoaded()
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                var ajaxLoader = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("preloader_2")));
                return ajaxLoader;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
