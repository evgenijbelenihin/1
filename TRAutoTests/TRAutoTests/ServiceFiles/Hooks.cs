using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TRAutoTests.ServiceFiles
{
    [Binding]
    class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            //var driver = new ChromeDriver();
            //Singleton.GetInstance();
            
            IWebDriver driver = Singleton.GetDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            ScenarioContext.Current["driver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Singleton.GetDriver().Quit();
            Singleton.driver = null;
            //((IWebDriver)ScenarioContext.Current["driver"]).Quit();
        }
    }
}
