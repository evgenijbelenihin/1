using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TRAutoTests.ServiceFiles
{
    public class Singleton
    {
        public static IWebDriver driver;

        /*private Singleton()
        {
            driver = new ChromeDriver();
        }*/

        public static IWebDriver GetDriver()
        {
            if (driver == null /*|| !IsSessionExist()*/) driver = new ChromeDriver();
            return driver;
        }

        /*private static bool IsSessionExist()
        {
            try
            {
                var check = driver.Title;
            }
            catch
            {
                return false;
            }
            return true;
        }*/

       /* public static IWebDriver GetDriver()
        {
            return driver;
        }*/
    }
}
