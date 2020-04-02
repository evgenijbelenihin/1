using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestApiProject.NewBookModelsPOM;

namespace TestApiProject.Steps
{
    [Binding]
    public class SignUpSteps
    {
        private IWebDriver _driver = (IWebDriver)ScenarioContext.Current["driver"];


        [Given(@"Sign Up page is opened")]
        public void GivenSignUpPageIsOpened()
        {
            new ClientSignUpPage(_driver).SignUpPageOpened();
        }
        
        [When(@"I fill the fields with data from table")]
        public void WhenIFillTheFieldsWithDataFromTable(Table table)
        {
            var model = table.CreateInstance<SignUpModel>();
            var signUpPage = new ClientSignUpPage(_driver);
            signUpPage.FillFirstNameField(model.FirstName);
            signUpPage.FillLastNameField(model.LastName);
            signUpPage.FillEmailField(UniqueEmail());
            signUpPage.FillPasswordField(model.Password);
            signUpPage.FillConfirmPasswordField(model.ConfirmPassword);
            signUpPage.FillPhoneNumberField(model.PhoneNumber);
        }
        
        [When(@"I press Next button")]
        public void WhenIPressNextButton()
        {
            new ClientSignUpPage(_driver).ClickNextButton();
        }
        
        [Then(@"I successfully signed up on NewBookModels")]
        public void ThenISuccessfullySignedUpOnNewBookModels()
        {
            Assert.True(new ClientSignUpPage(_driver).IsFinishButtonDisplayed());
        }

        [StepArgumentTransformation(@"Unique Email")]
        private string UniqueEmail()
        {
            return $"qwasd{DateTime.Now.ToString("mmss")}@qwe.qwea";
        }
    }
}
