using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApplication.Pages;

namespace SampleApplication.Tests
{
    [TestClass]
    public class SiteInspectionModule:BaseTest
    {
        [TestMethod]
        [TestCategory("SampleApplication")]
        public void SiteInspection_SubmitForFirstApproval_ValidFormData()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.GoTo();
            var customDashBoardPage = loginPage.Login("ankit", "pwd123");
            Assert.IsTrue(customDashBoardPage.IsVisible, "User not able to login successfully/Dashboard page not available");

            var siteInspectionPage = customDashBoardPage.GoToSiteInspection();
            Assert.IsTrue(siteInspectionPage.IsVisible, "Site Inspection page not available");


        }
    }
}
