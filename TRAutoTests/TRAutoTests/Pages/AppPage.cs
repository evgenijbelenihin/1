using OpenQA.Selenium;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAutoTests.Pages
{
    public class AppPage
    {
        private readonly string AppPageURL = "http://34.76.181.237/app";
        public IWebDriver _driver;

        //page's elements
        private readonly By logoImage = By.CssSelector("img[alt=logo]");

        internal string GetAppPageURL()
        {
            return AppPageURL;
        }

        internal void OpenAppPage()
        {
            _driver.Navigate().GoToUrl(AppPageURL);
        }

        public AppPage(IWebDriver driver)
        {
            _driver = driver;
        }

    }
}
