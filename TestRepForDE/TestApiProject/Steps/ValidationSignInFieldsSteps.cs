using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestApiProject.NewBookModelsPOM;

namespace TestApiProject.Steps
{
    [Binding]
    public class ValidationSignInFieldsSteps
    {
        private IWebDriver _driver = (IWebDriver)ScenarioContext.Current["driver"];

        [Given(@"Sign In page is opened")]
        public void GivenSignInPageIsOpened()
        {
            new SignInPage(_driver).SignInPageOpened();
        }
        
        [When(@"Fill the Email field with incorrect format value '(.*)'")]
        public void WhenFillTheEmailFieldWithIncorrectFormatValue(string incorrectFormatEmail)
        {
            new SignInPage(_driver).FillEmailField(incorrectFormatEmail);
            Thread.Sleep(1000);
        }

        [When(@"I change focus to password field element")]
        public void WhenIChangeFocusToPasswordFieldElement()
        {
            new SignInPage(_driver).FillPasswordField("");
        }

        [Then(@"I see the error message about incorrect Email format")]
        public void ThenISeeTheErrorMessageAboutIncorrectEmailFormat()
        {
            Thread.Sleep(2000);  
            Assert.IsTrue(new SignInPage(_driver).IsEmailErrorMessageDisplayed());
        }

        [When(@"Fill the Password field with incorrect format value '(.*)'")]
        public void WhenFillThePasswordFieldWithIncorrectFormatValue(string incorrectPasswordValue)
        {
            new SignInPage(_driver).FillPasswordField(incorrectPasswordValue);
        }

        [When(@"I change focus to Email element")]
        public void WhenIChangeFocusToEmailElement()
        {
            new SignInPage(_driver).FillEmailField("");
        }

        [Then(@"I see the error message about password required")]
        public void ThenISeeTheErrorMessageAboutPasswordRequired()
        {
            Assert.IsTrue(new SignInPage(_driver).IsPasswordErrorMessageDisplayed());
        }

    }
}
