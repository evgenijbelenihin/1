using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TestApiProject.NewBookModelsPOM
{
    public class SignInPage
    {
        private IWebDriver _driver;
        public SignInPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By EmailField = By.CssSelector("input[type=email]");
        private By PasswordField = By.CssSelector("input[type=password]");
        private By LogInButton = By.CssSelector("button[class^=SignInForm]");
        private By PasswordErrorMessage = By.XPath("/html/body/nb-app/ng-component/common-react-bridge/div/div[2]/div/form/section/section/div[2]/label/div[2]");
        private By EmailErrorMessage = By.CssSelector("div[class*=FormError] > div");
        public void FillEmailField(string email)
        {
            _driver.FindElement(EmailField).SendKeys(email);
        }

        public void FillPasswordField(string password)
        {
            _driver.FindElement(PasswordField).SendKeys(password);
        }

        public void ClickLogInButton()
        {
            _driver.FindElement(LogInButton).Click();
        }

        public void SignInPageOpened()
        {
            _driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
        }

        public bool IsLogInButtonDisplayed()
        {
            return _driver.FindElement(LogInButton).Displayed;
        }

        public string GetEmailErrorMessage()
        {
            return _driver.FindElement(By.CssSelector("div[class*=FormError] > div")).Text;
        }

        public bool IsEmailErrorMessageDisplayed()
        {
            return _driver.FindElement(EmailErrorMessage).Displayed;
        }
        public bool IsPasswordErrorMessageDisplayed()
        {
            return _driver.FindElement(PasswordErrorMessage).Displayed;
        }
        
        public void LoginUsingAPI(string token)
        {
            IJavaScriptExecutor js = (ChromeDriver)_driver;
            js.ExecuteScript($"localStorage.setItem('access_token','{token}');");
        }
    }
}
