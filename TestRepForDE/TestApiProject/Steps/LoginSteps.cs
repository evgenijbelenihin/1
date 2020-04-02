using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TestApiProject.ApiRequests.Models;
using TestApiProject.ApiRequests.NewBookModelsApi.Auth;
using TestApiProject.NewBookModelsPOM;

namespace TestApiProject.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver = (IWebDriver)ScenarioContext.Current["driver"];

        const string PASSWORD = "123qweQWE!";

        [Given(@"Client is created")]
        public void GivenClientIsCreated()
        { 
            ScenarioContext.Current["client"] = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = "qwasd" + DateTime.Now.ToString("mmss")+ "@qwe.qwea",
                Password = PASSWORD,
                FirstName = "sdfsadfsf",
                LastName = "asdadasdsad",
                PhoneNumber = "1231231231"
            });

        }
        
        [Given(@"Sign in page is opened")]
        public void GivenSignInPageIsOpened()
        {
            new SignInPage(_driver).SignInPageOpened();
        }
        
        [When(@"I input email of created lead in email field")]
        public void WhenIInputEmailOfCreatedLeadInEmailField()
        {
            var lead = (ClientAuthModel)ScenarioContext.Current["client"];
            new SignInPage(_driver).FillEmailField(lead.User.Email);
        }
        
        [When(@"I input default password of created lead in password field")]
        public void WhenIInputDefaultPasswordOfCreatedLeadInPasswordField()
        {
            new SignInPage(_driver).FillPasswordField(PASSWORD);
        }
        
        [When(@"I press Log in button")]
        public void WhenIPressLogInButton()
        {
            new SignInPage(_driver).ClickLogInButton();
        }
        
        [Then(@"I successfully logged in NewBookModels site as created client")]
        public void ThenISuccessfullyLoggedInNewBookModelsSiteAsCreatedClient()
        {
            Assert.True(new ClientSignUpPage(_driver).IsFinishButtonDisplayed());
        }
    }
}
