using OpenQA.Selenium;
using System.Threading;

namespace TestApiProject.NewBookModelsPOM
{
    
    public class ClientSignUpPage
    {
        private IWebDriver _driver;

        public ClientSignUpPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By FirstNameField = By.Name("first_name");
        private By LastNameField = By.Name("last_name");
        private By EmailField = By.CssSelector("input[type=email]");
        private By PasswordField = By.Name("password");
        private By ConfirmPasswordField = By.Name("password_confirm");
        private By PhoneNumberField = By.Name("phone_number");
        private By NextButton = By.CssSelector("button[class^=SignupForm]");


        private static readonly By FinishBtn = By.CssSelector("button[class^=SignupCompany]");
        public bool IsFinishButtonDisplayed()
        {
            Thread.Sleep(2000);
            return _driver.FindElement(FinishBtn).Displayed;
        }

        public void FillFirstNameField(string email)
        {
            _driver.FindElement(FirstNameField).SendKeys(email);
        }
        public void FillLastNameField(string email)
        {
            _driver.FindElement(LastNameField).SendKeys(email);
        }

        public void FillEmailField(string email)
        {
            _driver.FindElement(EmailField).SendKeys(email);
        }

        public void FillPasswordField(string password)
        {
            _driver.FindElement(PasswordField).SendKeys(password);
        }

        public void FillConfirmPasswordField(string password)
        {
            _driver.FindElement(ConfirmPasswordField).SendKeys(password);
        }

        public void FillPhoneNumberField(string password)
        {
            _driver.FindElement(PhoneNumberField).SendKeys(password);
        }

        public void ClickNextButton()
        {
            _driver.FindElement(NextButton).Click();
        }

        public void SignUpPageOpened()
        {
            _driver.Navigate().GoToUrl("https://newbookmodels.com/join");
        }
    }
}
