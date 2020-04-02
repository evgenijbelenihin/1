using java.awt;
using java.awt.datatransfer;
using java.awt.@event;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TestApiProject.NewBookModelsPOM
{
    class AccountSettings
    {
        private IWebDriver _driver;
        public AccountSettings(IWebDriver driver)
        {
            _driver = driver;
        }

        private By EditButton = By.CssSelector("div[title=edit]");
        private By ProfileSettingsSection = By.CssSelector("nb-link[class^=ml-6] > div[class^=link]");
        private By AccountInfoSection = By.CssSelector("div[class^=link]");
        private By SaveChangesButtonInProfileSection = By.CssSelector("button[type^=submit]");
        private By InputCompanyName = By.CssSelector("input[placeholder*='company name']");
        private By InputCompanyUrl = By.CssSelector("input[placeholder*=URL]");
        private By DescriptionField = By.CssSelector("textarea[placeholder*=description]");
        private By SignOutButton = By.CssSelector("div[class*=logout]");


        public void AccountSettingsPageIsOpened()
        {
            _driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
        }

        public void ClickSignOutButton()
        {
            _driver.FindElement(SignOutButton).Click();
        }

        public void ClickEditButton()
        {
            _driver.FindElement(EditButton).Click();
        }

        public void ClickProfileSettingsSection()
        {
            _driver.FindElement(ProfileSettingsSection).Click();
        }

        public void FillCompanyNameField(string CompanyName)
        {
            _driver.FindElement(InputCompanyName).SendKeys(CompanyName);
        }

        public void FillCompanyUrlField(string CompanyUrl)
        {
            _driver.FindElement(InputCompanyUrl).SendKeys(CompanyUrl);
        }

        public void FillDescriptionField(string CompanyName)
        {
            _driver.FindElement(DescriptionField).SendKeys(CompanyName);
        }

        public void ClickSaveChangesButtonInProfileSection()
        {
            _driver.FindElement(SaveChangesButtonInProfileSection).Click();
            Thread.Sleep(10000);
        }

        public void ClickAccountInfoSection()
        {
            _driver.FindElement(AccountInfoSection).Click();
        }

        public bool IsAvatarUploadedInProfileSettings()
        {
            return _driver.FindElement(By.CssSelector("div[class^=avatar__image]")).Displayed;
        }
        public void UploadImage()
        {
            _driver.FindElement(By.CssSelector("button[class*=w-100]")).Click();

            Clipboard clipboard = Toolkit.getDefaultToolkit().getSystemClipboard();
            StringSelection stringSelection = new StringSelection(AppDomain.CurrentDomain.BaseDirectory + @"Image\qwe.jpg");
            clipboard.setContents(stringSelection, null);
            
            Robot robot = new Robot();
            Thread.Sleep(2000);
            robot.keyPress(KeyEvent.VK_CONTROL);
            robot.keyPress(KeyEvent.VK_V);
            robot.keyRelease(KeyEvent.VK_CONTROL);
            robot.keyRelease(KeyEvent.VK_V);
            Thread.Sleep(2000);
            robot.keyPress(13);
            robot.keyRelease(13);
            Thread.Sleep(2000);
        }
    }
}
