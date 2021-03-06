﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TestApiProject
{
    [Binding]
    class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            ScenarioContext.Current["driver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            ((IWebDriver)ScenarioContext.Current["driver"]).Quit();
        }
    }
}
