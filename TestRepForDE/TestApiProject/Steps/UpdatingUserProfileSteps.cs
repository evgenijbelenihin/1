using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestApiProject.ApiRequests.Models;
using TestApiProject.ApiRequests.NewBookModelsApi.Auth;
using TestApiProject.NewBookModelsPOM;

namespace TestApiProject
{
    [Binding]
    public class UpdatingUserProfileSteps
    {
        private IWebDriver _driver = (IWebDriver)ScenarioContext.Current["driver"];

        [Given(@"Client is created by API")]
        public void GivenClientIsCreatedByAPI()
        {
            ScenarioContext.Current["client"] = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = "qwasd" + DateTime.Now.ToString("mmss") + "@qwe.qwea",
                Password = "123qweQWE!",
                FirstName = "sdfsadfsf",
                LastName = "asdadasdsad",
                PhoneNumber = "1231231231"
            });
        }
        
        [Given(@"I logged in NewBookModels by API")]
        public void GivenILoggedInNewBookModelsByAPI()
        {
            var signInPage = new SignInPage(_driver);
            signInPage.SignInPageOpened();
            signInPage.LoginUsingAPI(((ClientAuthModel)ScenarioContext.Current["client"]).TokenData.Token);
        }
        
        [Given(@"Account settings page is opened")]
        public void GivenAccountSettingsPageIsOpened()
        {
            new AccountSettings(_driver).AccountSettingsPageIsOpened();
        }
        
        [Given(@"Profile settings section in opened")]
        public void GivenProfileSettingsSectionInOpened()
        {
            new AccountSettings(_driver).ClickProfileSettingsSection();
        }
        
        [When(@"I press Edit button")]
        public void WhenIPressEditButton()
        {
            new AccountSettings(_driver).ClickEditButton();
        }
        
        [When(@"I fill the fields with data from the table")]
        public void WhenIFillTheFieldsWithDataFromTheTable(Table table)
        {
            var accountSettings = new AccountSettings(_driver);
            accountSettings.FillCompanyNameField(table.Rows[0]["CompanyName"]);
            accountSettings.FillCompanyUrlField(table.Rows[0]["CompanyUrl"]);
            accountSettings.FillDescriptionField(table.Rows[0]["Description"]);
            Thread.Sleep(2000);
        }
        
        [When(@"Avatar is chosen and uploaded")]
        public void WhenAvatarIsChosenAndUploaded()
        {
            new AccountSettings(_driver).UploadImage();

        }
        
        [When(@"I press Save Changes button")]
        public void WhenIPressSaveChangesButton()
        {
            Thread.Sleep(2000);
            new AccountSettings(_driver).ClickSaveChangesButtonInProfileSection();
        }
        
        [Then(@"User avatar successfully changed")]
        public void ThenUserAvatarSuccessfullyChanged()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(new AccountSettings(_driver).IsAvatarUploadedInProfileSettings());
        }
    }
}
