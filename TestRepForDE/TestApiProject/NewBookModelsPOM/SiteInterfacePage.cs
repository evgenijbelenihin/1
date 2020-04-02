using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApiProject.NewBookModelsPOM
{
    public class SiteInterfacePage
    {
        private IWebDriver _driver;
        public SiteInterfacePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By AccountSettingsButton = By.CssSelector("div[class*=avatar]");
        
        public void ClickAccountSettingsButton()
        {
            _driver.FindElement(AccountSettingsButton).Click();
        }


    }
}
