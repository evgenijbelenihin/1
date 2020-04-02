using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TestApiProject.ApiRequests.Models;
using TestApiProject.ApiRequests.NewBookModelsApi.Auth;
using TestApiProject.NewBookModelsPOM;

namespace TestApiProject
{
    [Binding]
    public class LogoutSteps
    {
        private IWebDriver _driver = (IWebDriver)ScenarioContext.Current["driver"];

        [Given(@"Client is created using API")]
        public void GivenClientIsCreatedUsingAPI()
        {
            ScenarioContext.Current["client"] = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = "qwasd" + DateTime.Now.ToString("mmss") + "@qwe.qwea",
                Password = "123qweQWE!",
                FirstName = "sdfsadfsf",
                LastName = "asdadasdsad",
                PhoneNumber = "1231231231"
            });
        }
        
        [Given(@"I logged in NewBookModels using API")]
        public void GivenILoggedInNewBookModelsUsingAPI()
        {
            var signInPage = new SignInPage(_driver);
            signInPage.SignInPageOpened();
            signInPage.LoginUsingAPI(((ClientAuthModel)ScenarioContext.Current["client"]).TokenData.Token);
        }

        [When(@"Account settings page is opened")]
        public void WhenAccountSettingsPageIsOpened()
        {
            new AccountSettings(_driver).AccountSettingsPageIsOpened();
        }
        
        [When(@"I press Logout button")]
        public void WhenIPressLogoutButton()
        {
            new AccountSettings(_driver).ClickSignOutButton();
        }
        
        [Then(@"I successfully logged out from NewBookModels")]
        public void ThenISuccessfullyLoggedOutFromNewBookModels()
        {
            Assert.IsTrue(new SignInPage(_driver).IsLogInButtonDisplayed());
        }
    }
}
