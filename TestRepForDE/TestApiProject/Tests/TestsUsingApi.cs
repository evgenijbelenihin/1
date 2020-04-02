using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
using TestApiProject.ApiRequests.Models;
using TestApiProject.ApiRequests.NewBookModelsApi.Auth;
using TestApiProject.ApiRequests.NewBookModelsApi.Client;
using System.Net;

namespace TestApiProject.Tests
{
    [TestFixture]
    class TestsUsingApi
    {
        const string USER_EMAIL = "qweasdasd@qwe.qwea";
        const string PASSWORD = "123qweQWE!";
        

        [Test]
        public void CheckThatIsPossibleToCreateNewUserUsingApi()
        {
            var expectedEmail = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss");
            var client = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = expectedEmail,
                Password = PASSWORD,
                FirstName = "sdfsadfsf",
                LastName = "asdadasdsad",
                PhoneNumber = "1231231231"
            });

            Assert.Multiple(() =>
            {
                Assert.That(client.User.Id != null && client.User.Id != string.Empty);
                Assert.IsTrue(client.User.Email == expectedEmail);
            });
        }


        [Test]
        public void CheckThatLoginUsingTokenFromApiInBrowserIsPossible()
        {
            Context.Token = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                Password = PASSWORD,
                FirstName = "qweqwe",
                LastName = "qweqweqwe",
                PhoneNumber = "1431231231"
            }).TokenData.Token;

            var driver = new ChromeDriver();
            IJavaScriptExecutor js = driver;
            driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            js.ExecuteScript($"localStorage.setItem('access_token','{Context.Token}');");
            driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            Thread.Sleep(3000);
            var result = driver.FindElement(By.CssSelector("div[class^='Avatar'] > div[class^='AvatarClient']")).Displayed;
            driver.Quit();
            Assert.IsTrue(result);
        }


        [Test]
        public void CheckThatIsPossibleToChangeAvatarByApi()
        {
            Context.Token = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                Password = PASSWORD,
                FirstName = "qweqwe",
                LastName = "qweqweqwe",
                PhoneNumber = "1431231231"
            }).TokenData.Token;

            var uploadedAvatarId = new ClientRequests().SendRequestUploadUserAvatar(AppDomain.CurrentDomain.BaseDirectory+@"Image\qwe.jpg").Image.Id;
            var responseOfSettingAvatar = new ClientRequests().SendRequestSetNewAvatar(new AvatarSetModel{AvatarId = uploadedAvatarId});
            var expectedSetAvatarId = responseOfSettingAvatar.Avatar.Id;

            Assert.Multiple(() =>
            {
                Assert.IsFalse(uploadedAvatarId.ToString().Equals(null));
                Assert.AreEqual(expectedSetAvatarId, uploadedAvatarId);
            });
        }

        [Test]
        public void CheckThatIsPossibleToDownloadUserAvatarByApi()
        {
            Context.Token = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                Password = PASSWORD,
                FirstName = "qweqwe",
                LastName = "qweqweqwe",
                PhoneNumber = "1431231231"
            }).TokenData.Token;

            var clientInfoResponse = new ClientRequests().SendRequestToGetClientInfo();
            
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(clientInfoResponse.Avatar.Original.url, @"H:\avatar.jpg");
            }

            Assert.IsTrue(File.Exists(@"H:\avatar.jpg"));
        }

        [Test]
        public void CheckThatIsPossibleToChangePasswordByApi()
        {
            var leadRegistrationData = new ClientSignUpModel
            {
                Email = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                Password = PASSWORD,
                FirstName = "qweqwe",
                LastName = "qweqweqwe",
                PhoneNumber = "1431231231"
            };

            var authRequests = new AuthRequests();
            var leadRegistrationResponseData = authRequests.SendRequestSignUpPost(leadRegistrationData);
            Context.Token = leadRegistrationResponseData.TokenData.Token;

            var response = new PasswordRequests().SendRequestChangePassword(new PasswordModel
            {
                OldPassword = PASSWORD,
                NewPassword = "123qweQWE!@"
            });

            Assert.IsTrue(response.Contains(Context.Token));
        }

        [Test]
        public void CheckThatIsPossibleToChangeGeneralInformationByApi()
        {
            Context.Token = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                Password = PASSWORD,
                FirstName = "qweqwe",
                LastName = "qweqweqwe",
                PhoneNumber = "1431231231"
            }).TokenData.Token;

            var expectedIndustry = "apparel";
            var expectedCompanyWebsite = "http://zaxzax.com";

            var profile = new ClientRequests().SendRequestUpdateProfileInformation(new ClientProfileModel
            {
                CompanyWebsite = expectedCompanyWebsite,
                Industry = expectedIndustry
            });

            Assert.Multiple(() =>
            {
                Assert.IsTrue(profile.Industry == expectedIndustry);
                Assert.IsTrue(profile.CompanyWebsite == expectedCompanyWebsite);
            });
        }
    }
}