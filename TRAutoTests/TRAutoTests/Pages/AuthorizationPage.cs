using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using TRAutoTests.ServiceFiles;

namespace TRAutoTests.Pages
{
    public class AuthorizationPage : IPage
    {
        //private readonly string AuthPageURL = "http://34.76.181.237/";
        //public IWebDriver _driver;

        //page's elements
        //private readonly By logoImage = By.CssSelector("img[alt=logo]");
        //private readonly By inputEmail = By.CssSelector("input[data-at=auth-page-email-input]");
        //private readonly By inputPassword = By.CssSelector("input[data-at=auth-page-password-input]");
        //private readonly By signInButton = By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[2]/button[1]");
        //private readonly By signUpButton = By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[2]/button[2]");
        //private readonly By settingsButton = By.CssSelector("img[alt=settings]");
        //private readonly By errorMessageOutput = By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[1]/div[2]/output");
        //private readonly By signInTitle = By.CssSelector("h1[data-at=auth-page-title-name]");
        //private readonly By forgotPasswordButton = By.CssSelector("a[data-at=auth-page-forgot-password-button]");
        //private readonly By labelPasswordField = By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[1]/div[2]/label");
        //private readonly By labelEmailField = By.CssSelector("label[data-at=dataAttributeLabelItem]");

        [FindsBy(How = How.CssSelector, Using = "img[alt=logo]")]
        private IWebElement logoImage;
        [FindsBy(How = How.CssSelector, Using = "input[data-at=auth-page-email-input]")]
        private IWebElement inputEmail;
        [FindsBy(How = How.CssSelector, Using = "input[data-at=auth-page-password-input]")]
        private IWebElement inputPassword;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div[2]/div[2]/button[1]")]
        private IWebElement signInButton;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div[2]/div[2]/button[2]")]
        private IWebElement signUpButton;
        [FindsBy(How = How.CssSelector, Using = "img[alt=settings]")]
        private IWebElement settingsButton;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div[2]/div[1]/div[2]/output")]
        private IWebElement errorMessageOutput;
        [FindsBy(How = How.CssSelector, Using = "h1[data-at=auth-page-title-name]")]
        private IWebElement signInTitle;
        [FindsBy(How = How.CssSelector, Using = "a[data-at=auth-page-forgot-password-button]")]
        private IWebElement forgotPasswordButton;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div[2]/div[1]/div[2]/label")]
        private IWebElement labelPasswordField;
        [FindsBy(How = How.CssSelector, Using = "label[data-at=dataAttributeLabelItem]")]
        private IWebElement labelEmailField;
        public string AuthPageURL { get;} = BasePageURL;

        internal string GetAuthPageURL()
        {
            return AuthPageURL;
        }

        internal void OpenAuthPage()
        {
            _driver.Navigate().GoToUrl(AuthPageURL);
        }

        public AuthorizationPage()
        {
            _driver = Singleton.GetDriver();
            PageFactory.InitElements(_driver, this);
        }

        internal void FillEmailField(string email)
        {
            inputEmail.SendKeys(email);
        }

        internal void FillPasswordField(string password)
        {
            inputPassword.SendKeys(password);
        }

        internal void ClickSignUpButton()
        {
            signUpButton.Click();
        }

        internal void ClickSignInButton()
        {
            signInButton.Click();
        }

        internal ForgotPassword OpenForgotPasswordModalWindow()
        {
            forgotPasswordButton.Click();
            return new ForgotPassword();
        }

        internal void ClickSettingsButton()
        {
           settingsButton.Click();
        }

        internal bool IsLogoExist()
        {
            return logoImage.Displayed;
        }

        internal bool IsErrorMessageDisplayed()
        {
            return errorMessageOutput.Displayed;
        }

        internal bool IsAuthPageOpened()
        {
            return (_driver.Url == AuthPageURL);
        }

        internal bool IsSignInPageTitleExist()
        {
            return signInTitle.Displayed;
        }

        internal string GetErrorMessageText()
        {
            return errorMessageOutput.Text;
        }

        internal bool IsInputEmailDisplayed()
        {
            return inputEmail.Displayed;
        }

        internal bool IsInputPasswordDisplayed()
        {
            return inputPassword.Displayed;
        }

        internal bool IsSignInButtonDisplayed()
        {
            return signInButton.Displayed;
        }

        internal bool IsSignUpButtonDisplayed()
        {
            return signUpButton.Displayed;
        }

        internal bool IsSettingsButtonDisplayed()
        {
            return settingsButton.Displayed;
        }

        internal bool IsForgotPasswordButtonDisplayed()
        {
            return forgotPasswordButton.Displayed;
        }

        internal string GetTitleText()
        {
            return signInTitle.Text;
        }

        internal string GetSignInButtonName()
        {
            return signInButton.Text;
        }

        internal string GetSignUpButtonName()
        {
            return signUpButton.Text;
        }

        internal string GetTextFromEmailInput()
        {
            return inputEmail.GetAttribute("value");
        }

        internal string GetTextFromPasswordInput()
        {
            return inputPassword.GetAttribute("value");
        }

        internal string GetTypeOfPasswordField()
        {
            return inputPassword.GetAttribute("type");
        }

        internal Settings OpenSettingsModalWindow()
        {
            settingsButton.Click();
            return new Settings();
        }

        internal string GetEmailFieldLabel()
        {
            return labelEmailField.Text;
        }

        internal string GetPasswordFieldLabel()
        {
            return labelPasswordField.Text;
        }

        internal class ForgotPassword : IPage
        {
            //public IWebDriver _driver;

            private readonly By inputEmail = By.CssSelector("input[data-at=forgot-pass-email-input]");
            private readonly By inputPhoneNumber = By.CssSelector("input[data-at=forgot-pass-phone-number-input]");
            private readonly By restorePasswordButton = By.CssSelector("button[data-at='forgot-pass-restore-password-button']");
            private readonly By backButton = By.CssSelector("img[alt=logo]");
            private readonly By forgotPasswordPageTitle = By.CssSelector("h3");
            private readonly By errorMessageOutput = By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/output/span");
            
            public ForgotPassword()
            {
                _driver = Singleton.GetDriver();
            }

            internal bool IsForgotPasswordPageOpened()
            {
                return _driver.FindElement(forgotPasswordPageTitle).Displayed;
            }

            internal bool IsInputEmailDisplayed()
            {
                return _driver.FindElement(inputEmail).Displayed;
            }

            internal bool IsInputPhoneNumberDisplayed()
            {
                return _driver.FindElement(inputPhoneNumber).Displayed;
            }

            internal bool IsRestorePasswordButtonDisplayed()
            {
                return _driver.FindElement(restorePasswordButton).Displayed;
            }

            internal bool IsBackButtonDisplayed()
            {
                return _driver.FindElement(backButton).Displayed;
            }

            internal void FillEmailField(string email)
            {
                _driver.FindElement(inputEmail).SendKeys(email);
            }

            internal void FillPhoneNumberField(string email)
            {
                _driver.FindElement(inputPhoneNumber).SendKeys(email);
            }

            internal void ClickRestorePasswordButton()
            {
                _driver.FindElement(restorePasswordButton).Click();
            }

            internal void ClickBackButton()
            {
                _driver.FindElement(backButton).Click();
            }

            internal bool IsErrorMessageDisplayed()
            {
                return _driver.FindElement(errorMessageOutput).Displayed;
            }

            internal string GetErrorMessageText()
            {
                return _driver.FindElement(errorMessageOutput).Text;
            }
        }

        internal class Settings : IPage
        {
            //public IWebDriver _driver;

            private readonly By selectChooseLanguage = By.CssSelector("select[data-at=modal-settings-locale-select]");
            private readonly By selectChooseTheme = By.CssSelector("select[data-at=modal-settings-theme-select]");
            private readonly By backButton = By.CssSelector("img[alt=logo]");
            private readonly By settingsTitle = By.CssSelector("h1[class]");

            public Settings()
            {
                _driver = Singleton.GetDriver();
            }

            internal void ClickBackButton()
            {
                _driver.FindElement(backButton).Click();
            }

            internal bool IsSettingsTitleDisplayed()
            {
                return _driver.FindElement(settingsTitle).Displayed;
            }
            
            internal void SelectTheme(string newTheme)
            {
                var select = new SelectElement(_driver.FindElement(selectChooseTheme));
                select.SelectByValue(newTheme);
            }

            internal string GetThemeFromLocalStorage()
            {
                IJavaScriptExecutor js = (ChromeDriver)_driver;
                return (string)js.ExecuteScript($"return localStorage.getItem('theme');");
            }

        }
    }
}
