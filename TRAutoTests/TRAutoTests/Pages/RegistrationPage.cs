using OpenQA.Selenium;
using static TRAutoTests.Pages.AuthorizationPage;

namespace TRAutoTests.Pages
{
    public class RegistrationPage : IPage
    {
        //private readonly string RegPageURL = "http://34.76.181.237/reg";
        private string RegPageURL { get; } = $"{BasePageURL}reg";

        //page's elements
        private readonly By inputFirstName = By.CssSelector("input[data-at=reg-page-first-name-input]");
        private readonly By inputLastName = By.CssSelector("input[data-at=reg-page-last-name-input]");
        private readonly By inputEmail = By.CssSelector("input[data-at=reg-page-email-input]");
        private readonly By inputPassword = By.CssSelector("input[data-at=reg-page-password-input]");
        private readonly By inputConfirmPassword = By.CssSelector("input[data-at=reg-page-confirm-password-input]");
        private readonly By inputPhoneNumber = By.CssSelector("input[class*=iZDr]");
        private readonly By inputBirthDate = By.CssSelector("input[data-at=reg-page-date-of-birth-input]");
        private readonly By signUpButton = By.CssSelector("input[data-at=reg-page-sign-up-button]");
        private readonly By backToSignInButton = By.Name("a[data-at=reg-page-back-to-auth-link]");
        private readonly By RegPageTitle = By.CssSelector("h1[class]");
        private readonly By errorMessageOutput = By.Name("output[class*=kJYW]");
        private readonly By logoImage = By.CssSelector("img[alt=logo]");
        private readonly By settingsButton = By.CssSelector("img[alt=settings]");
        //settings button?

        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        internal void OpenRegPage()
        {
            _driver.Navigate().GoToUrl(RegPageURL);
        }

        internal void FillFirstNameField(string firstName)
        {
            _driver.FindElement(inputFirstName).SendKeys(firstName);
        }

        internal void FillLastNameField(string lastName)
        {
            _driver.FindElement(inputLastName).SendKeys(lastName);
        }

        internal void FillEmailField(string email)
        {
            _driver.FindElement(inputEmail).SendKeys(email);
        }

        internal void FillPasswordField(string password)
        {
            _driver.FindElement(inputPassword).SendKeys(password);
        }

        internal void FillConfirmPasswordField(string confirmPassword)
        {
            _driver.FindElement(inputConfirmPassword).SendKeys(confirmPassword);
        }

        internal void FillPhoneNumberField(string phoneNumber)
        {
            _driver.FindElement(inputPhoneNumber).SendKeys(phoneNumber);
        }

        internal void FillBirthDateField(string birthDate)
        {
            _driver.FindElement(inputBirthDate).SendKeys(birthDate);
        }

        internal void ClickSignUpButton()
        {
            _driver.FindElement(signUpButton).Click();
        }

        internal bool IsRegPageOpened()
        {
            return (_driver.Url == RegPageURL);
        }

        internal void ClickBackToSignInButton()
        {
            _driver.FindElement(backToSignInButton).Click();
        }

        internal bool IsErrorMessageDisplayed()
        {
            return _driver.FindElement(errorMessageOutput).Displayed;
        }

        internal string GetErrorMessageText()
        {
            return _driver.FindElement(errorMessageOutput).Text;
        }

        internal bool IsInputFirstNameDisplayed()
        {
            return _driver.FindElement(inputFirstName).Displayed;
        }

        internal bool IsInputLastNameDisplayed()
        {
            return _driver.FindElement(inputLastName).Displayed;
        }

        internal bool IsInputEmailDisplayed()
        {
            return _driver.FindElement(inputEmail).Displayed;
        }

        internal bool IsInputPasswordDisplayed()
        {
            return _driver.FindElement(inputPassword).Displayed;
        }

        internal bool IsInputConfirmPasswordDisplayed()
        {
            return _driver.FindElement(inputConfirmPassword).Displayed;
        }

        internal bool IsInputPhoneNumberDisplayed()
        {
            return _driver.FindElement(inputPhoneNumber).Displayed;
        }

        internal bool IsInputBirthDateDisplayed()
        {
            return _driver.FindElement(inputBirthDate).Displayed;
        }

        internal bool IsSignUpButtonDisplayed()
        {
            return _driver.FindElement(signUpButton).Displayed;
        }

        internal bool IsBackToSignInButtonDisplayed()
        {
            return _driver.FindElement(backToSignInButton).Displayed;
        }

        internal bool IsSignUpTitleDisplayed()
        {
            return _driver.FindElement(RegPageTitle).Displayed;
        }

        internal bool IsLogoExist()
        {
            return _driver.FindElement(logoImage).Displayed;
        }

        internal Settings OpenSettingsModalWindow()
        {
            _driver.FindElement(settingsButton).Click();
            return new Settings();
        }








    }
}
