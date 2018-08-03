using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SeleniumTest2.SRC.AbstractTest;

namespace SeleniumTest2.SRC.PageObojects
{

    class AbstractPage
    {
        protected IWebDriver driver;
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [FindsBy(How = How.LinkText, Using = "More...")]
        private IWebElement MoreLabel { get; set; }

        [FindsBy(How = How.LinkText, Using = "News")]
        private IWebElement NewsLabel { get; set; }

        [FindsBy(How = How.LinkText, Using = "Privacy Policy")]
        private IWebElement PrivacyPolicy { get; set; }

        public AbstractPage()
        {
            driver = AbstractTest.GetDriver();
            driver.Manage().Window.Maximize();
            new WebDriverWait(driver, System.TimeSpan.FromSeconds(5)).Until(
            d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            PageFactory.InitElements(driver, this);
            
        }

        public NewsPage GoToNews()
        {
            log.Info("Clicking on News link");
            Actions action = new Actions(driver);

            if (((RemoteWebDriver)driver).Capabilities.BrowserName.Equals(BrowserType.Chrome.ToString().ToLower()))
            {
                MoreLabel.Click();
                action.MoveToElement(MoreLabel).Build().Perform();
                NewsLabel.Click();
            }
            else
            {
                action.MoveToElement(MoreLabel).MoveToElement(NewsLabel).Click(NewsLabel).Build().Perform();
            }
            return new NewsPage();
        }

        internal void TakeScreenshot(String title)
        {

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + title + ".png");
            ss.SaveAsFile(path);
            log.Info("Taking screenshot: ");

        }

        internal PrivacyPolicyPage OpenPrivacyPolicyInNewTab()
        {
            log.Info("Opening Privacy Policy in new tab");

            PrivacyPolicy.SendKeys(Keys.Control + Keys.Return);
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            return new PrivacyPolicyPage(driver.WindowHandles.Last());
        }


    }
}
