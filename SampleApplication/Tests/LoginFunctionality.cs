using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using AutomationResources;
using SampleApplication.Pages;

namespace SampleApplication.Tests
{
    [TestClass]
    public class LoginFunctionality:BaseTest
    {
        [TestMethod]
        [TestCategory("SampleApplication")]
        public void Login_LogInToApplication_ValidCredentials()
        {            
            var loginPage = new LoginPage(Driver);
            loginPage.GoTo();
            var customDashBoardPage = loginPage.Login("ankit", "pwd123");
            Assert.IsTrue(customDashBoardPage.IsVisible, "User not able to login successfully/Dashboard page not available");
        }

        [TestMethod]
        [TestCategory("SampleApplication")]
        public void Login_LogInToApplication_InValidPassword()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.GoTo();
            var customDashBoardPage = loginPage.Login("ankit", "pwd123");
            Assert.IsTrue(loginPage.LoginErrorMessage, "User not able to login successfully/Dashboard page not available");
        }
    }
}
