using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TechTalk.SpecFlow;
using TRAutoTests.Pages;
using TRAutoTests.ServiceFiles;

namespace TRAutoTests.Steps
{
    [Binding]
    public class SignIn
    {
        private IWebDriver _driver = Singleton.GetDriver();//(IWebDriver)ScenarioContext.Current["driver"];

        [Given(@"I have an URL")]
        public void GivenIHaveAnURL()
        {
            Assert.IsFalse(new AuthorizationPage().GetAuthPageURL().Equals(null));
        }

        [When(@"I open Sign In page")]
        public void WhenIOpenSignInPage()
        {
            new AuthorizationPage().OpenAuthPage();
        }

        [Then(@"Sign In page is opened")]
        public void ThenSignInPageIsOpened()
        {
            Assert.IsTrue(new AuthorizationPage().IsAuthPageOpened());
        }

        [Then(@"Logo is displayed")]
        public void ThenLogoIsDisplayed()
        {
            Assert.IsTrue(new AuthorizationPage().IsLogoExist());
        }

        [Then(@"Email input exist")]
        public void ThenEmailInputExist()
        {
            Assert.IsTrue(new AuthorizationPage().IsInputEmailDisplayed());
        }

        [Then(@"Password input exist")]
        public void ThenPasswordInputExist()
        {
            Assert.IsTrue(new AuthorizationPage().IsInputPasswordDisplayed());
        }

        [Then(@"Title of page named '(.*)'")]
        public void ThenTitleOfPageNamed(string expectedTitle)
        {
            Assert.IsTrue(new AuthorizationPage().GetTitleText().Equals(expectedTitle));
        }

        [Then(@"Sign In button exist")]
        public void ThenSignInButtonExist()
        {
            Assert.IsTrue(new AuthorizationPage().IsSignInButtonDisplayed());
        }

        [Then(@"Sign Up button exist")]
        public void ThenSignUpButtonExist()
        {
            Assert.IsTrue(new AuthorizationPage().IsSignUpButtonDisplayed());
        }

        [Then(@"Name of Sign In button is '(.*)'")]
        public void ThenNameOfSignInButtonIs(string expectedName)
        {
            Assert.IsTrue(new AuthorizationPage().GetSignInButtonName().Equals(expectedName));
        }

        [Then(@"Name of Sign Up button is '(.*)'")]
        public void ThenNameOfSignUpButtonIs(string expectedName)
        {
            Assert.IsTrue(new AuthorizationPage().GetSignUpButtonName().Equals(expectedName));
        }

        [Given(@"I open Sign In page")]
        public void GivenIOpenSignInPage()
        {
            new AuthorizationPage().OpenAuthPage();
        }

        [When(@"I fill (.*) symbols to email input field")]
        public void WhenIFillSymbolsToEmailInputField(int quantityOfSymbols)
        {
            string str = null;
            for (int i = 0; i < quantityOfSymbols; i++)
            {
                str += "Q";
            }
            new AuthorizationPage().FillEmailField(str);
        }

        [Then(@"In email input field is exist (.*) symbols")]
        public void ThenInEmailInputFieldIsExistSymbols(int quantityOfSymbols)
        {
            Assert.IsTrue(new AuthorizationPage().GetTextFromEmailInput().Length == quantityOfSymbols);
        }

        [When(@"I fill (.*) symbols to password input field")]
        public void WhenIFillSymbolsToPasswordInputField(int quantityOfSymbols)
        {
            string str = null;
            for (int i = 0; i < quantityOfSymbols; i++)
            {
                str += "Q";
            }
            new AuthorizationPage().FillPasswordField(str);
        }

        [Then(@"In password input field is exist (.*) symbols")]
        public void ThenInPasswordInputFieldIsExistSymbols(int quantityOfSymbols)
        {
            Assert.IsTrue(new AuthorizationPage().GetTextFromPasswordInput().Length == quantityOfSymbols);
        }

        [When(@"I fill in email field '(.*)'")]
        public void WhenIFillInEmailField(string email)
        {
            new AuthorizationPage().FillEmailField(email);
        }

        [When(@"I fill in password field '(.*)'")]
        public void WhenIFillInPasswordField(string password)
        {
            new AuthorizationPage().FillPasswordField(password);
        }

        [When(@"I press Sign In button")]
        public void WhenIPressSignInButton()
        {
            new AuthorizationPage().ClickSignInButton();
        }


        [Then(@"I do not sign in to account and got error")]
        public void ThenIDoNotSignInToAccountAndGotError()
        {
            Assert.IsTrue(new AuthorizationPage().IsErrorMessageDisplayed()); 
        }

        [Then(@"Password input field has password type")]
        public void ThenPasswordInputFieldHasPasswordType()
        {
            Assert.IsTrue(new AuthorizationPage().GetTypeOfPasswordField().Equals("password"));
        }

        [Then(@"I successfully signed in")]
        public void ThenISuccessfullySignedIn()
        {
            Thread.Sleep(500);
            Assert.IsTrue(Singleton.GetDriver().Url.Equals(new AppPage(_driver).GetAppPageURL()));
        }

        [When(@"I press Sign Up button")]
        public void WhenIPressSignUpButton()
        {
            new AuthorizationPage().ClickSignUpButton();
        }

        [Then(@"Sign Up page is opened")]
        public void ThenSignUpPageIsOpened()
        {
            Assert.IsTrue(new RegistrationPage(_driver).IsRegPageOpened());
        }

        [Then(@"Forgot password button is exist")]
        public void ThenForgotPasswordButtonIsExist()
        {
            new AuthorizationPage().IsForgotPasswordButtonDisplayed();
        }

        [When(@"I press Forgot Password button")]
        public void WhenIPressForgotPasswordButton()
        {
            new AuthorizationPage().OpenForgotPasswordModalWindow();
            Thread.Sleep(2000);
        }

        [Then(@"Forgot Password modal window is opened")]
        public void ThenForgotPasswordModalWindowIsOpened()
        {
            Assert.IsTrue(new AuthorizationPage.ForgotPassword().IsForgotPasswordPageOpened());

        }

        [When(@"I chose new theme '(.*)'")]
        public void WhenIChoseNewTheme(string theme)
        {
            new AuthorizationPage.Settings().SelectTheme(theme);
        }

        [Then(@"Theme is changed to '(.*)'")]
        public void ThenThemeIsChangedTo(string theme)
        {
            Thread.Sleep(500);
            Assert.IsTrue(new AuthorizationPage.Settings().GetThemeFromLocalStorage().Equals(theme));
        }

        [When(@"I open Settings modal window")]
        public void WhenIOpenSettingsModalWindow()
        {
            new AuthorizationPage().ClickSettingsButton();
        }

        [Then(@"Value in email field equals '(.*)'")]
        public void ThenValueInEmailFieldEquals(string expectedEmail)
        {
            Assert.AreEqual(expectedEmail, new AuthorizationPage().GetTextFromEmailInput());
        }

        [Then(@"Label of Email field is '(.*)'")]
        public void ThenLabelOfEmailFieldIs(string fieldLabel)
        {
            Assert.AreEqual(fieldLabel, new AuthorizationPage().GetEmailFieldLabel());
        }

        [Then(@"Label of Password field is '(.*)'")]
        public void ThenLabelOfPasswordFieldIs(string fieldLabel)
        {
            Assert.AreEqual(fieldLabel, new AuthorizationPage().GetPasswordFieldLabel());
        }

        [Then(@"I got error '(.*)'")]
        public void ThenIGotError(string expectedError)
        {
            Assert.AreEqual(expectedError, new AuthorizationPage().GetErrorMessageText());
        }

        [Given(@"I press forgot password button")]
        public void GivenIPressForgotPasswordButton()
        {
          new AuthorizationPage().OpenForgotPasswordModalWindow();
        }


        [When(@"I fill email '(.*)' from table")]
        public void WhenIFillEmailFromTable(string email)
        {
            new AuthorizationPage.ForgotPassword().FillEmailField(email);
        }

        [When(@"I fill phone number (.*) from table")]
        public void WhenIFillPhoneNumberFromTable(string phoneNumber)
        {
            new AuthorizationPage.ForgotPassword().FillPhoneNumberField(phoneNumber);
        }


        [When(@"I press Restore password button")]
        public void WhenIPressRestorePasswordButton()
        {
            new AuthorizationPage.ForgotPassword().ClickRestorePasswordButton();
        }

        [Then(@"'(.*)' is displayed")]
        public void ThenIsDisplayed(string message)
        {
            string str = new AuthorizationPage.ForgotPassword().GetErrorMessageText();
            Assert.IsTrue(str.Equals(message));
        }






    }
}
