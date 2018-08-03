using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest2.SRC
{
     public class AbstractTest
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected static IWebDriver driver;
        protected BrowserType browser;
        public enum BrowserType
        {
            IE,
            Chrome,
            Firefox,
            PhantomJS
        }

        public AbstractTest(BrowserType browser)
        {
            this.browser = browser;
        }

        public static IWebDriver GetDriver() {
            return driver;
        }

        [SetUp]
        public void InitializeDriver()
        {
            log.Info("Initializing driver...");
            switch (browser)
            {
                case BrowserType.IE:
                    break;
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.default_directory", AppDomain.CurrentDomain.BaseDirectory);
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case BrowserType.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.SetPreference("browser.download.dir", AppDomain.CurrentDomain.BaseDirectory);
                    firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
                    firefoxOptions.SetPreference("browser.download.manager.showWhenStarting", false);
                    firefoxOptions.SetPreference("browser.download.folderList", 2);
                    firefoxOptions.SetPreference("pdfjs.disabled", true);


                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                case BrowserType.PhantomJS:
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            log.Info("Driver initializec successfully");

        }

        [TearDown]
        public void FixtureTearDown()
        {
            if (driver != null) driver.Quit();
            log.Info("Closing driver");

        }
    }
}
